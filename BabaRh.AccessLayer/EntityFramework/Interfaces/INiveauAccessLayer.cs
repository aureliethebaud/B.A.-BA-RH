namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface INiveauAccessLayer
    {
        Task<int> AddAsync(Niveau niveau);

        Task<bool> UpdateAsync(Niveau niveau);

        Task<bool> DeleteAsync(int NiveauId);

        Niveau Get(int NiveauId);

        List<Niveau> GetAll();

    }
}
