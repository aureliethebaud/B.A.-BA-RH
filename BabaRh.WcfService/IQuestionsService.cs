using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BabaRh.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IQuestionsService
    {

        [OperationContract]
        int AddQuestion(AjoutQuestion question);

    }

       
    [DataContract]
    public class AjoutQuestion
    {
        [DataMember]
        public int QuestionId { get; set; }
        
        [DataMember]
        public string ModuleLib { get; set; }
        [DataMember]
        public string QuestionLib { get; set; }
    }
}
