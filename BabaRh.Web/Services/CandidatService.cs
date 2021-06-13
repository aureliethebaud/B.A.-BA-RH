using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BabaRh.Web.Services
{
    using BabaRh.Web.Models.ViewModel;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class CandidatService
    {
        private readonly HttpClient httpClient;

        public CandidatService()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44388")
            };
        }

        public async Task<List<CandidatVM>> GetAll()
        {
            var response = await this.httpClient.GetAsync($"/api/candidats");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var candidats = JsonConvert.DeserializeObject<List<CandidatVM>>(responseBody);

                return candidats;
            }

            return null;
        }

        public async Task<bool> Create(CandidatVM candidat)
        {
            var content = new StringContent(JsonConvert.SerializeObject(candidat), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/candidats", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}