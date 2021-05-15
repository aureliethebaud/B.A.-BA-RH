using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
    public class QuestionAccessLayer : IQuestionAccessLayer
    {
        private readonly BabaRhDbContext context;

        private static QuestionAccessLayer instance;
        public static QuestionAccessLayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuestionAccessLayer();

                return instance;
            }

        }
        private QuestionAccessLayer()
        {
            this.context = new BabaRhDbContext();
        }


        /// <summary>
        ///       Permet l'ajout d'une question dans la base de données.
        /// </summary>
        /// <param name="question">Question à ajouter.</param>
        /// <returns>L'identifiant de la question ajoutée.</returns>
        public int Add(Question question)
        {
            this.context.Questions.Add(question);
            this.context.SaveChanges();

            return question.QuestionId;
        }


        /// <summary>
        ///       Permet la mise à jour d'une question dans la base de données.
        /// </summary>
        /// <param name="question">Question à mettre à jour.</param>
        /// <returns>La question modifiée.</returns>
        public Question Update(Question question)
        {
            var questionToUpdate = this.Get(question.QuestionId);

            if (questionToUpdate != null)
            {
                questionToUpdate.QuestionLib = question.QuestionLib;
                questionToUpdate.ModuleLib = question.ModuleLib;
            }

            this.context.SaveChanges();

            return question;
        }


        /// <summary>
        ///       Permet la suppression d'une question de la base de données.
        /// </summary>
        /// <param name="questionId">Identifiant de la question à supprimer.</param>
        public void Delete(int questionId)
        {
            var questionToDelete = this.Get(questionId);
            if (questionToDelete != null)
            {
                this.context.Questions.Remove(questionToDelete);
                this.context.SaveChanges();
            }
            else
            {
                throw new Exception("La question n'existe pas");
            }
        }

        /// <summary>
        ///       Permet de retourner une question de la base de données.
        /// </summary>
        /// <param name="questionId">Identifiant de la question à retourner.</param>
        /// <returns>La question retournée.</returns>
        public Question Get(int questionId)
        {
            return this.context.Questions.SingleOrDefault(x => x.QuestionId == questionId);
        }



        /// <summary>
        ///       Permet de retourner toutes les questions de la base de données.
        /// </summary>
        /// <returns>La liste des questions retournée.</returns>
        public List<Question> GetAll()
        {
            return this.context.Questions.ToList();
        }

    }
}

