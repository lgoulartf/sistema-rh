using System.Text;

namespace SistemaRHDesktop
{
    public class Api
    {
        HttpClient Client;
        public Api()
        {
            string url = "http://localhost:8081";
            string ambiente = Environment.GetEnvironmentVariable("ambiente", EnvironmentVariableTarget.Machine);
            
            if (ambiente == "dev")
            {
                url = "http://localhost:5227";
            }

            Client = new HttpClient
            {
                BaseAddress = new Uri(url),
            };

            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> Get(string rota)
        {
            var result = await Client.GetAsync(rota);

            var data = await result.Content.ReadAsStringAsync();

            return data;
        }

        public async Task<string> Post(string rota, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await Client.PostAsync(rota, content);

            var data = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(data);
            }

            return data;
        }

        public async Task<string> Put(string rota, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var result = await Client.PutAsync(rota, content);

            var data = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(data);
            }

            return data;
        }

        public async Task Delete(string rota)
        {
            var result = await Client.DeleteAsync(rota);

            if (!result.IsSuccessStatusCode)
            {
                var message = await result.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }
    }
}
