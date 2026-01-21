using Emploees.Data;
using Emploees.Domain;
using Emploees.Infrastucture.AD;
using Microsoft.EntityFrameworkCore;

namespace Emploees.Application
{
    public interface IAdUserService
    {
        Task<AdUser[]> GetAdUsersAsync();
        Task<AdUser[]> LoadAdUsersAsync();
        Task Refresh();
    }

    public class AdUserService(AdClient adClient, IDbContextFactory<ApplicationDbContext> dbFactory) : IAdUserService
    {
        public async Task<AdUser[]> GetAdUsersAsync()
        {
            using var dbContext = dbFactory.CreateDbContext();

            return await dbContext.AdUsers.AsNoTracking().ToArrayAsync();
        }

        public Task<AdUser[]> LoadAdUsersAsync() => adClient.GetAdUsersAsync();

        public async Task Refresh()
        {
            var loaded = await LoadAdUsersAsync();

            using var dbContext = dbFactory.CreateDbContext();

            foreach (var item in loaded)
            {
                var existing = dbContext.AdUsers.FirstOrDefault(e => e.Sid == item.Sid);
                if (existing is null)
                    dbContext.AdUsers.Add(item);
                else
                    dbContext.Entry(existing).CurrentValues.SetValues(item);
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
