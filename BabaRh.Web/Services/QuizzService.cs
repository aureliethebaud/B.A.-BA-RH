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


    public class QuizzService
    {
        private readonly HttpClient httpClient;

        public QuizzService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public QuizzService()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44388")
            };
        }


        public async Task<QuizzVM> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/quizzes/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quizz = JsonConvert.DeserializeObject<QuizzVM>(responseBody);

                return quizz;
            }

            return null;
        }

        public async Task<List<QuizzVM>> GetAll()
        {
            var response = await this.httpClient.GetAsync($"/api/quizzes");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quizzes = JsonConvert.DeserializeObject<List<QuizzVM>>(responseBody);

                return quizzes;
            }

            return null;
        }

        public async Task<bool> Create(QuizzVM quizz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quizz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/quizzes", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(QuizzVM quizz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quizz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/quizzes/{quizz.QuizzId}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/quizzes/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}