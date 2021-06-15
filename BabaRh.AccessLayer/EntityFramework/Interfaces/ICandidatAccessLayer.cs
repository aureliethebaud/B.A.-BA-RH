namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICandidatAccessLayer
    {
        Task<int> AddAsync(Candidat candidat);

        Task<bool> UpdateAsync(Candidat candidat);

        Task<bool> DeleteAsync(int candidatId);

        Candidat Get(int candidatId);

        List<Candidat> GetAll();

    }
}
