using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
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
        public void Add(Module module)
        {
            this.context.Modules.Add(module);
            this.context.SaveChanges();
           
        }
      

        /// <summary>
        ///       Permet la mise à jour d'un module dans la base de données.
        /// </summary>
        /// <param name="module">Module à mettre à jour.</param>
        /// <returns>Le module modifié.</returns>
        public Module Update(Module module)
        {
            var moduleToUpdate = this.Get(module.ModuleLib);

            if (moduleToUpdate != null)
            {
                moduleToUpdate.ModuleLib = module.ModuleLib;
            }

            this.context.SaveChanges();
            return module;
        }


        /// <summary>
        ///       Permet la suppression d'un module de la base de données.
        /// </summary>
        /// <param name="moduleLib">Identifiant du module à supprimer.</param>
        public void Delete(string moduleLib)
        {
            var moduleToDelete = this.Get(moduleLib);
            if (moduleToDelete != null)
            {
                this.context.Modules.Remove(moduleToDelete);
                this.context.SaveChanges();
            }
            else
            {
                throw new Exception("Le module n'existe pas");
            }
        }


        /// <summary>
        ///       Permet de retourner un module de la base de données.
        /// </summary>
        /// <param name="moduleLib">Identifiant du module à retourner.</param>
        /// <returns>Le module retourné.</returns>
        public Module Get(string moduleLib)
        {
            return this.context.Modules.SingleOrDefault(x => x.ModuleLib == moduleLib);
        }


        /// <summary>
        ///       Permet de retourner tous les modules de la base de données.
        /// </summary>
        /// <returns>La liste des modules retournée.</returns>
        public List<Module> GetAll()
        {
            return this.context.Modules.ToList();
        }
    }

}

