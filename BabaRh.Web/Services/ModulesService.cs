using BabaRh.Web.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BabaRh.Web.Services
{
    public class ModulesService
    {

        private HttpClient httpClient;

        public ModulesService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44388");
        }


        public async Task<IList<ModuleVM>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/modules");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var modules = JsonConvert.DeserializeObject<List<ModuleVM>>(responseBody);

                return modules;
            }

            return new List<ModuleVM>();
        }

        public async Task<Module> Get(string moduleLib)
        {
            var response = await this.httpClient.GetAsync($"/api/modules/{moduleLib}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var module = JsonConvert.DeserializeObject<Module>(responseBody);

                return module;
            }

            return null;
        }


        public async Task<bool> Create(ModuleVM moduleVM)
        {
            var content = new StringContent(JsonConvert.SerializeObject(moduleVM), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/modules", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


        public async Task<bool> Update(string moduleLib, ModuleVM moduleVM)
        {
            var content = new StringContent(JsonConvert.SerializeObject(moduleVM), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/modules/{moduleLib}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}