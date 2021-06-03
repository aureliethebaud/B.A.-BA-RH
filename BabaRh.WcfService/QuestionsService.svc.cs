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

        public bool DeleteQuestion(int QuestionId)
        {
            if (this.questionAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }
            if (QuestionId <= 0)
            {
                return false;
            }
            this.questionAccessLayer.Delete(QuestionId);
            return true;
        }

        public QuestionOutput GetQuestion(int QuestionId)
        {
            if (this.questionAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (QuestionId <= 0)
            {
                throw new Exception("L'id n'est pas au format attendu");
            }

            var questionUpdated = this.questionAccessLayer.Get(QuestionId);

            return questionUpdated != null ? this.TransformQuestionToQuestionOutput(questionUpdated) : null;
        }

        public List<QuestionOutput> GetQuestions()
        {
            if (this.questionAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            var questions = this.questionAccessLayer.GetAll();
            var questionsReturned = new List<QuestionOutput>();


            foreach (var x in questions)
            {
                questionsReturned.Add(this.TransformQuestionToQuestionOutput(x));
            }

            return questionsReturned;
        }

        public QuestionOutput UpdateQuestion(UpdateQuestionInput question)
        {
            if (this.questionAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (question == null)
            {
                throw new Exception("Impossible de réaliser l'update d'une ressource nulle");
            }

            var questionUpdated = this.questionAccessLayer.Update(new Question()
            {
                QuestionId = question.QuestionId,
                QuestionLib = question.QuestionLib,
                ModuleLib = question.ModuleLib,                
            });

            return this.TransformQuestionToQuestionOutput(questionUpdated);
        }

        private QuestionOutput TransformQuestionToQuestionOutput(Question q)
        {
            return new QuestionOutput
            {
                QuestionId = q.QuestionId,
                ModuleLib = q.ModuleLib,
                QuestionLib = q.QuestionLib,

            };
        }

       
    }
}
