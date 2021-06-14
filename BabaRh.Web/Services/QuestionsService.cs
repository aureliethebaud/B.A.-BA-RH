namespace BabaRh.Web.Services
{
    using BabaRh.Web.Models.ViewModel;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class QuestionsService
    {
        private readonly HttpClient httpClient;

        public QuestionsService()
        {
            this.httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:44388")
            };
        }

        public async Task<QuestionVM> Get(int id)
        {
            var question = await this.httpClient.GetAsync($"/api/questions/{id}");

            if (question.IsSuccessStatusCode)
            {
                string responseBody = await question.Content.ReadAsStringAsync();
                var reponse = JsonConvert.DeserializeObject<QuestionVM>(responseBody);

                return reponse;
            }

            return null;
        }

        public async Task<List<QuestionVM>> GetAll()
        {
            var response = await this.httpClient.GetAsync($"/api/questions");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var questions = JsonConvert.DeserializeObject<List<QuestionVM>>(responseBody);

                return questions;
            }

            return null;
        }

        public async Task<bool> Create(QuestionVM question)
        {
            var content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/questions", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateAsync(QuestionVM question)
        {
            var content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/questions/{question.QuestionId}", content);

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