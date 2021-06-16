namespace BabaRh.Web.Services
{
    using BabaRh.Web.Models.ViewModel;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class ModulesService
    {

        private readonly HttpClient httpClient;

        public ModulesService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44388");
        }


        public async Task<List<ModuleVM>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/modules");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var modules = JsonConvert.DeserializeObject<List<ModuleVM>>(responseBody);

                return modules;
            }


            return null;
        }

        public async Task<ModuleVM> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/modules/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var module = JsonConvert.DeserializeObject<ModuleVM>(responseBody);

                return module;
            }

            return null;
        }


        public async Task<bool> Create(ModuleVM module)
        {
            var content = new StringContent(JsonConvert.SerializeObject(module), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/modules", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public async Task<bool> UpdateAsync(ModuleVM module)
        {
            var content = new StringContent(JsonConvert.SerializeObject(module), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/modules/{module.ModuleId}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/candidats/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}