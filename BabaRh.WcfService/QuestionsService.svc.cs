using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BabaRh.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionAccessLayer questionAccessLayer;
        public QuestionsService()
        {
            this.questionAccessLayer = QuestionAccessLayer.Instance;
        }

        public int AddQuestion(AjoutQuestion question)
        {
            if (this.questionAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (question == null)
            {
                throw new Exception("L'objet ajouté ne peut pas être null");
            }

            return this.questionAccessLayer.Add(new Question
            {
                QuestionLib = question.QuestionLib,
                ModuleLib = question.ModuleLib

            });
        }
    }
}
