namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IQuizzAccessLayer
    {
        Task<int> AddAsync(Quizz quizz);

        Task<Quizz> UpdateAsync(Quizz quizz);

        Task<bool> DeleteAsync(int quizzId);

        Quizz Get(int quizzId);

        List<Quizz> GetAll();

    }
}
