using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface IQuestionAccessLayer
    {
        Task<int> AddAsync(Question question);

        Task<bool> UpdateAsync(Question question);

        Task<bool> DeleteAsync(int questionId);

        Question Get(int questionId);

        List<Question> GetAll();

    }
}
