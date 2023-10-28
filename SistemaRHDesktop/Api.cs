using System.Net;
using System.Security.Policy;
using System.Text;

namespace SistemaRHDesktop
{
    public class Api
    {
        HttpClient Client;
        string Url = "http://localhost:8081";

        public Api()
        {
            string ambiente = Environment.GetEnvironmentVariable("ambiente", EnvironmentVariableTarget.Machine);
            
            if (ambiente == "dev")
            {
                Url = "http://localhost:5227";
            }

            Client = new HttpClient
            {
                BaseAddress = new Uri(Url),
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

        public async Task DownloadData(string rota)
        {
            var response = await Client.GetAsync(rota);
            var content = await response.Content.ReadAsByteArrayAsync();

            File.WriteAllBytes("./folha-pagamento.pdf", content);
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
