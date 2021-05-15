using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface QuestionAccessLayer
    {
        int Add(Question question);

        Question Update(Question question);

        void Delete(int questionId);

        Question Get(int questionId);

        List<Question> GetAll();

    }
}
