using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface IReponseAccessLayer
    {
        Task<int> AddAsync(Reponse reponse);

        Task<bool> UpdateAsync(Reponse reponse);

        Task<bool> DeleteAsync(int reponseId);

        Reponse Get(int reponseId);

        List<Reponse> GetAll();

    }
}
