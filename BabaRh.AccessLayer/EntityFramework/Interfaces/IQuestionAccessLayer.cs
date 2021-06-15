namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuestionAccessLayer
    {
        Task<int> AddAsync(Question question);

        Task<bool> UpdateAsync(Question question);

        Task<bool> DeleteAsync(int questionId);

        Question Get(int questionId);

        List<Question> GetAll();

    }
}
