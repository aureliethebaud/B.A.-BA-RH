using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface IQuizzAccessLayer
    {
        Task<int> AddAsync(Quizz quizz);

        Task<Quizz> UpdateAsync(Quizz quizz);

        Task<bool> DeleteAsync(int quizzId);

        Quizz Get(int quizzId);

        List<Quizz> GetAll();

    }
}
