using Emploees.Data;
using Emploees.Domain;
using Emploees.Infrastucture.Buh;
using Microsoft.EntityFrameworkCore;

namespace Emploees.Application
{
    public interface IBuhService
    {
        Task<Catalog_Сотрудники_Buh[]> GetCatalog();
        Task<Catalog_Сотрудники_Buh[]> LoadCatalog();
        Task RefreshCatalog();
    }

    public class BuhService(BuhClient buhClient, IDbContextFactory<ApplicationDbContext> dbFactory) : IBuhService
    {
        public async Task RefreshCatalog()
        {
            var loaded = await LoadCatalog();

            using var dbContext = dbFactory.CreateDbContext();

            foreach (var item in loaded)
            {
                var existing = dbContext.Catalog_Сотрудники_Buh.FirstOrDefault(e => e.Ref_Key == item.Ref_Key);
                if (existing is null)
                    dbContext.Catalog_Сотрудники_Buh.Add(item);
                else
                    dbContext.Entry(existing).CurrentValues.SetValues(item);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<Catalog_Сотрудники_Buh[]> GetCatalog()
        {
            using var dbContext = dbFactory.CreateDbContext();

            var result = await dbContext.Catalog_Сотрудники_Buh.AsNoTracking().ToArrayAsync();

            return result;
        }

        public async Task<Catalog_Сотрудники_Buh[]> LoadCatalog()
        {
            var result = await buhClient.GetValue<RootObject<Catalog_Сотрудники_Buh>>(Catalog_Сотрудники.Uri);

            return result?.Value ?? [];
        }
    }
}
