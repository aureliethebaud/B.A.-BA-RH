using BabaRh.Web.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace BabaRh.Web.Services
{
    public class ModuleService
    {
        private HttpClient httpClient;

        public ModuleService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44388");
        }


        public async Task<ModuleVM> Get(string label)
        {
            var response = await this.httpClient.GetAsync($"/api/modules/{label}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var module = JsonConvert.DeserializeObject<ModuleVM>(responseBody);

                return module;
            }

            return null;
        }
    }
}