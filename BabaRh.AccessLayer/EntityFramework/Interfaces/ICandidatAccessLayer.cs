using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface ICandidatAccessLayer
    {
        int Add(Candidat candidat);

        Candidat Update(Candidat candidat);

        void Delete(int candidatId);

        Candidat Get(int candidatId);

        List<Candidat> GetAll();

    }
}
