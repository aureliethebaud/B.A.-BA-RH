using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BabaRh.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IReponsesService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IReponsesService
    {
        [OperationContract]
        int AddReponse(AjoutReponse reponse);

        [OperationContract]
        bool DeleteReponse(int ReponseId);

        [OperationContract]
        ReponseOutput GetReponse(int ReponseId);

        [OperationContract]
        List<ReponseOutput> GetReponses();

        [OperationContract]
        ReponseOutput UpdateReponse(UpdateReponseInput reponse);
    }

    [DataContract]
    public class ReponseBase
    {
        [DataMember]
        public int ReponseId { get; set; }

        [DataMember]
        public string ReponseLib { get; set; }

        [DataMember]
        public bool IsOk { get; set; }

        [DataMember]
        public string QuestionId { get; set; }
    }

    [DataContract]
    public class AjoutReponse : ReponseBase
    {
    }

    [DataContract]
    public class ReponseOutput : ReponseBase
    {
    }

    [DataContract]
    public class UpdateReponseInput : ReponseBase 
    {
    }
}

