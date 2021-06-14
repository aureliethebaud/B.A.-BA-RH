namespace BabaRh.Web.Services
{

    using BabaRh.Web.Models.ViewModel;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class ReponsesService
    {

        private readonly HttpClient httpClient;

        public ReponsesService()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44388")
            };
        }

        public async Task<ReponseVM> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/reponses/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var reponse = JsonConvert.DeserializeObject<ReponseVM>(responseBody);

                return reponse;
            }

            return null;
        }

        public async Task<List<ReponseVM>> GetAll()
        {
            var response = await this.httpClient.GetAsync($"/api/reponses");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var reponses = JsonConvert.DeserializeObject<List<ReponseVM>>(responseBody);

                return reponses;
            }

            return null;
        }

        public async Task<bool> Create(ReponseVM reponse)
        {
            var content = new StringContent(JsonConvert.SerializeObject(reponse), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/reponses", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(ReponseVM reponse)
        {
            var content = new StringContent(JsonConvert.SerializeObject(reponse), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/candidats/{reponse.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/reponses/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}