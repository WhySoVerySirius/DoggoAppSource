using DoggosApi.Models;
using Newtonsoft.Json;

namespace DoggosApi.Data
{
    public class ApiDataProvider
    {
        public async Task<List<ApiData>>? GetData(string apiUrl, string apiKey)
        {
            List<ApiData>? apiData = new();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-api-key", apiKey);
                using (var response = await client.GetAsync(apiUrl))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK) return apiData;
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    apiData = JsonConvert.DeserializeObject<List<ApiData>>(apiResponse);
                    return apiData;
                }
            }
        }
    }
}
