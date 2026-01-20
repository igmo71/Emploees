using Emploees.Domain;
using Microsoft.Extensions.Options;

namespace Emploees.Infrastucture.AD
{
    public class AdClient(HttpClient httpClient, IOptions<AdConfig> options)
    {
        private readonly AdConfig _adConfig = options.Value;
        internal async Task<AdUser[]> GetAdUsersAsync()
        {
            var result = await httpClient.GetFromJsonAsync<AdUser[]>(_adConfig.AdUsers);

            return result ?? [];
        }
    }
}
