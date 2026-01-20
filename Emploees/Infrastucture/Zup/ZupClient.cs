using Microsoft.Extensions.Options;

namespace Emploees.Infrastucture.Zup
{
    public class ZupClient(HttpClient httpClient, IOptions<ZupConfig> options)
    {
        private readonly ZupConfig _zupConfig = options.Value;

        public Task<TValue?> GetValue<TValue>(string? uri)
        {
            return httpClient.GetFromJsonAsync<TValue>($"{_zupConfig.ODataUri}/{uri}");
        }
    }
}
