using Microsoft.Extensions.Options;

namespace Emploees.Infrastucture.Buh
{
    public class BuhClient(HttpClient httpClient, IOptions<BuhConfig> options)
    {
        private readonly BuhConfig _buhConfig = options.Value;

        public Task<TValue?> GetValue<TValue>(string? uri)
        {
            return httpClient.GetFromJsonAsync<TValue>($"{_buhConfig.ODataUri}/{uri}");
        }
    }
}
