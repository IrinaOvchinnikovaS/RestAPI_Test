namespace RestAPI_Test.Repositories
{
    public class AbstractRepository
    {
        private readonly HttpClient httpClient;

        public AbstractRepository(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task<string> GetAllFromSourceAsync(string url)
        {
            string result = string.Empty;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
