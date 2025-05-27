using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class ApiServiceMedidor
    {

        private readonly HttpClient _httpClient;

        public ApiServiceMedidor()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8091/medidores/") // URL base del endpoint
            };
        }

        public async Task<List<Medidor>> GetMedidorsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Medidor>>(json);
            }

            // Si falla, retorna lista vacía
            return new List<Medidor>();
        }

        //Solo medidores Activos
        public async Task<List<Medidor>> GetMedidoresActivosAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("activos");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Medidor>>(json);
            }

            return new List<Medidor>();
        }

        //Medidores filtrados por un predio
        public async Task<List<Medidor>> GetMedidoresPorPredioAsync(long idPredio)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"byPredio/{idPredio}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Medidor>>(json);
            }

            return new List<Medidor>();
        }

    }
}
