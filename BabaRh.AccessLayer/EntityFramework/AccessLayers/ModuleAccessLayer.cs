namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
    using BabaRh.AccessLayer.EntityFramework.Interfaces;
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;


    public class ModuleAccessLayer : IModuleAccessLayer
    {
        private readonly BabaRhDbContext context;

        private static ModuleAccessLayer instance;
        public static ModuleAccessLayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new ModuleAccessLayer();

                return instance;
            }

        }
        private ModuleAccessLayer()
        {
            this.context = new BabaRhDbContext();
        }


        /// <summary>
        ///       Permet l'ajout d'un module dans la base de données.
        /// </summary>
        /// <param name="module">Module à ajouter.</param>
        public async Task<int> AddAsync(Module module)
        {
            this.context.Modules.Add(module);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return module.ModuleId;
        }


        /// <summary>
        ///       Permet la suppression d'un module de la base de données.
        /// </summary>
        /// <param name="moduleLib">Identifiant du module à supprimer.</param>
        public async Task<bool> DeleteAsync(int moduleId)
        {
            var moduleToDelete = this.Get(moduleId);
            if (moduleToDelete != null)
            {
                this.context.Modules.Remove(moduleToDelete);
                this.context.SaveChanges();

                var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

                return result > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///       Permet de retourner un module de la base de données.
        /// </summary>
        /// <param name="moduleLib">Identifiant du module à retourner.</param>
        /// <returns>Le module retourné.</returns>
        public Module Get(int moduleId)
        {
            return this.context.Modules.AsQueryable().SingleOrDefault(x => x.ModuleId == moduleId);
        }

        /// <summary>
        ///       Permet de retourner tous les modules de la base de données.
        /// </summary>
        /// <returns>La liste des modules retournée.</returns>
        public List<Module> GetAll()
        {
            return this.context.Modules.AsQueryable().ToList();
        }


        /// <summary>
        ///       Permet la mise à jour d'un module dans la base de données.
        /// </summary>
        /// <param name="module">Module à mettre à jour.</param>
        /// <returns>Le module modifié.</returns>
        public async Task<bool> UpdateAsync(Module module)
        {
            var moduleToUpdate = this.context.Modules.FirstOrDefault(m => m.ModuleId == module.ModuleId);

            if (module == null)
                return false;

            moduleToUpdate.ModuleLib = module.ModuleLib;


            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }

    

    
    }
}
