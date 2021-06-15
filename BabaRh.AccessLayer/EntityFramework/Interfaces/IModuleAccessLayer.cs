namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IModuleAccessLayer
    {
        Task<int> AddAsync(Module module);

        Task<bool> UpdateAsync(Module module);

        Task<bool> DeleteAsync(int moduleId);

        Module Get(int moduleId);

        List<Module> GetAll();

    }
}
