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

        [OperationContract]
        bool DeleteQuestion(int QuestionId);

        [OperationContract]
        QuestionOutput GetQuestion(int QuestionId);

        [OperationContract]
        List<QuestionOutput> GetQuestions();

        [OperationContract]
        QuestionOutput UpdateQuestion(UpdateQuestionInput question);
    }

       
    [DataContract]
    public class QuestionBase
    {
        [DataMember]
        public int QuestionId { get; set; }
        
        [DataMember]
        public string ModuleLib { get; set; }
        [DataMember]
        public string QuestionLib { get; set; }
    }
    [DataContract]
    public class AjoutQuestion : QuestionBase
    {
    }

    [DataContract]
    public class QuestionOutput : QuestionBase
    {
    }

    [DataContract]
    public class UpdateQuestionInput : QuestionBase
    {
    }
}
