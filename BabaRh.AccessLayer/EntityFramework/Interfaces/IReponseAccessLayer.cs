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
        int Add(Reponse reponse);

        Reponse Update(Reponse reponse);

        void Delete(int reponseId);

        Reponse Get(int reponseId);

        List<Reponse> GetAll();

    }
}
