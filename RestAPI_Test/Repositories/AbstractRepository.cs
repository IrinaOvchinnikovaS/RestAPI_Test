namespace RestAPI_Test.Repositories
{
    public class AbstractRepository
    {
        public async Task<string> GetAllFromSourceAsync(string url)
        {
            string result;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
