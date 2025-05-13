using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Cliente
{

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8091/predios/") // URL del servidor
            };
        }

        public async Task<List<Residencial>> GetResidencialesAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Residencial>>(json);
            }

            return new List<Residencial>(); // Retorna lista vacía si hay error
        }

        public async Task<List<Residencial>> GetResidencialesByEstratoGreaterAsync(int estrato)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"estrato/greater/{estrato}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Residencial>>(json);
            }

            return new List<Residencial>();
        }

        public async Task<List<Residencial>> GetResidencialesByEstratoLessAsync(int estrato)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"estrato/less/{estrato}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Residencial>>(json);
            }

            return new List<Residencial>();
        }

        public async Task<List<Residencial>> GetResidencialesByEstratoRangeAsync(int min, int max)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"estrato/rango?min={min}&max={max}");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Residencial>>(json);
            }

            return new List<Residencial>();
        }

        
    }
}
