using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface IModuleAccessLayer
    {
        void AddAsync(Module module);

        Task<bool> UpdateAsync(Module module);

        void Delete(string moduleLib);

        Module Get(string moduleLib);

        List<Module> GetAll();

    }
}
