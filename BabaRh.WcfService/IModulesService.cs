using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BabaRh.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IModuleService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IModulesService
    {
        [OperationContract]
        void AddModule(AjoutModule module);
    }

    [DataContract]
    public class AjoutModule
    {
 
        [DataMember]
        public string ModuleLib { get; set; }

    }
}
