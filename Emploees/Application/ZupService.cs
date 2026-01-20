using Emploees.Data;
using Emploees.Domain;
using Emploees.Infrastucture.Zup;
using Microsoft.EntityFrameworkCore;

namespace Emploees.Application
{
    public interface IZupService
    {
        Task<Catalog_Сотрудники_Zup[]> GetCatalog();
        Task<Catalog_Сотрудники_Zup[]> LoadCatalog();
        Task RefreshCatalog();
    }

    public class ZupService(ZupClient zupClient, IDbContextFactory<ApplicationDbContext> dbFactory, ILogger<ZupClient> logger) : IZupService
    {
        public async Task RefreshCatalog()
        {
            var loaded = await LoadCatalog();

            using var dbContext = dbFactory.CreateDbContext();

            foreach (var item in loaded)
            {
                var existing = dbContext.Catalog_Сотрудники_Zup.FirstOrDefault(e => e.Ref_Key == item.Ref_Key);
                if (existing is null)
                    dbContext.Catalog_Сотрудники_Zup.Add(item);
                else
                    dbContext.Entry(existing).CurrentValues.SetValues(item);
            }
            await dbContext.SaveChangesAsync();
        }

        public async Task<Catalog_Сотрудники_Zup[]> GetCatalog()
        {
            using var dbContext = dbFactory.CreateDbContext();

            var result = await dbContext.Catalog_Сотрудники_Zup.AsNoTracking().ToArrayAsync();

            return result;
        }

        public async Task<Catalog_Сотрудники_Zup[]> LoadCatalog()
        {
            var result = await zupClient.GetValue<RootObject<Catalog_Сотрудники_Zup>>(Catalog_Сотрудники.Uri);

            logger.LogDebug("{Source} {Result}", nameof(GetCatalog), result);

            return result?.Value ?? [];
        }
    }
}
