namespace BabaRh.Web.Services
{
    using BabaRh.Web.Models.ViewModel;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class NiveauxService
    {
        private readonly HttpClient httpClient;

        public NiveauxService()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44388")
            };
        }


        public async Task<List<NiveauVM>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/niveaux");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var niveaux = JsonConvert.DeserializeObject<List<NiveauVM>>(responseBody);

                return niveaux;
            }


            return null;
        }

        public async Task<NiveauVM> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/niveaux/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var niveau = JsonConvert.DeserializeObject<NiveauVM>(responseBody);

                return niveau;
            }

            return null;
        }


        public async Task<bool> Create(NiveauVM niveau)
        {
            var content = new StringContent(JsonConvert.SerializeObject(niveau), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/niveaux", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public async Task<bool> UpdateAsync(NiveauVM niveau)
        {
            var content = new StringContent(JsonConvert.SerializeObject(niveau), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/niveaux/{niveau.NiveauId}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/niveaux/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}