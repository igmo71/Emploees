using Emploees.Data;
using Emploees.Domain;
using Microsoft.EntityFrameworkCore;

namespace Emploees.Application
{
    public interface IUtService
    {
        Task<Пользователь_СхемаПредприятия[]> Get_Пользователь_СхемаПредприятия();
    }

    public class UtService(IDbContextFactory<ApplicationDbContext> dbFactory) : IUtService
    {
        public async Task<Пользователь_СхемаПредприятия[]> Get_Пользователь_СхемаПредприятия()
        {
            using var dbContext = dbFactory.CreateDbContext();

            var result = await dbContext.Пользователь_СхемаПредприятия
                .AsNoTracking()
                .Include(e => e.Пользователь)
                .Include(e => e.СхемаПредприятия)
                .ToArrayAsync();
            return result;
        }
    }
}
