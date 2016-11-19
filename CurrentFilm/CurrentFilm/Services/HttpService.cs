using System.Net.Http;
using System.Threading.Tasks;


namespace CurrentFilm.Service
{
    public static class UriRequest
    {
        public static async Task<string> SendGetRequestAsync(string uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            return await responseMessage.Content.ReadAsStringAsync();
        }
    }
}
