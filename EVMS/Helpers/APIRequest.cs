using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EVMS.Helpers
{
    public class APIRequest<T>
    {
        static string BaseUrl = "http://localhost:5195/";
        public static async Task<T> Get(string url)
        {
            url = BaseUrl + url;

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    using (var response = await client.GetAsync(string.Format(url)))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var objsJsonString = await response.Content.ReadAsStringAsync();
                            var jsonContent = JsonConvert.DeserializeObject<T>(objsJsonString);

                            return jsonContent;
                        }
                        else
                        {
                            return default(T);
                        }
                    }
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}
