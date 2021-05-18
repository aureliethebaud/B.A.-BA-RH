using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BabaRh.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ModuleService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ModuleService.svc ou ModuleService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ModulesService : IModulesService
    {
        private readonly IModuleAccessLayer moduleAccessLayer;
        public ModulesService()
        {
            this.moduleAccessLayer = ModuleAccessLayer.Instance;
        }

        public void AddModule(AjoutModule module)
        {
            if (this.moduleAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (module == null)
            {
                throw new Exception("L'objet ajouté ne peut pas être null");
            }

           this.moduleAccessLayer.Add(new Module
            {
                ModuleLib = module.ModuleLib

            });

        }
    }
}

