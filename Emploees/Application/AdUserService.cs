using Emploees.Domain;
using Emploees.Infrastucture.AD;

namespace Emploees.Application
{
    public interface IAdUserService
    {
        Task<AdUser[]> GetAdUsersAsync();
        Task<AdUser[]> LoadAdUsersAsync();
    }

    public class AdUserService(AdClient adClient) : IAdUserService
    {
        public Task<AdUser[]> GetAdUsersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<AdUser[]> LoadAdUsersAsync()
        {
            var result = await adClient.GetAdUsersAsync();

            return result;
        }
    }
}
