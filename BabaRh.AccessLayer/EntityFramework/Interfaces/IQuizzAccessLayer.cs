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
        int Add(Quizz quizz);

        Quizz Update(Quizz quizz);

        void Delete(int quizzId);

        Quizz Get(int quizzId);

        List<Quizz> GetAll();

    }
}
