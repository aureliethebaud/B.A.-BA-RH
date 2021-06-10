using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;

    interface IQuizzModuleAccessLayer
    {
        int Add(QuizzModule quizz);

        void Delete(int quizzId, string moduleLib);

        QuizzModule Get(int quizzId, string moduleLib);

        List<QuizzModule> GetAll();
    }
}
