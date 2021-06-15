namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IReponseAccessLayer
    {
        Task<int> AddAsync(Reponse reponse);

        Task<bool> UpdateAsync(Reponse reponse);

        Task<bool> DeleteAsync(int reponseId);

        Reponse Get(int reponseId);

        List<Reponse> GetAll();

    }
}
