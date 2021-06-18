namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
    using BabaRh.AccessLayer.EntityFramework.Interfaces;
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;


    public class QuizzAccessLayer : IQuizzAccessLayer
    {
        private readonly BabaRhDbContext context;

        private static QuizzAccessLayer instance;
        public static QuizzAccessLayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new QuizzAccessLayer();

                return instance;
            }

        }
        private QuizzAccessLayer()
        {
            this.context = new BabaRhDbContext();
        }

        /// <summary>
        ///       Permet de retourner un quizz de la base de données.
        /// </summary>
        /// <param name="quizzId">Identifiant du quizz à retourner.</param>
        /// <returns>Le quizz retourné.</returns>
        public Quizz Get(int quizzId)
        {
            return this.context.Quizzs.AsQueryable().AsNoTracking()
                .Include(q => q.QuizzQuestion)
                .Include(q => q.QuizzQuestion.Select(qq => qq.Question))
                .Include(q => q.QuizzQuestion.Select(qq => qq.Question).Select(qqm => qqm.Niveau))
                .Include(q => q.QuizzQuestion.Select(qq => qq.Question).Select(qqm => qqm.Module))
                .Include(q => q.QuizzQuestion.Select(qq => qq.Question).Select(qqr => qqr.Reponse))
                .Include(q => q.Candidat)
                .Include(q => q.QuizzModule)
                .Include(q => q.QuizzModule.Select(mq => mq.Module))
                .SingleOrDefault(x => x.QuizzId == quizzId);
        }

        /// <summary>
        ///       Permet de retourner tous les quizzs de la base de données.
        /// </summary>
        /// <returns>La liste des quizzs retournée.</returns>
        public List<Quizz> GetAll()
        {
            return this.context.Quizzs.AsQueryable().AsNoTracking()
                .Include(q => q.Candidat)
                .Include(q => q.QuizzModule.Select(mq => mq.Module))
                .ToList();
        }

        /// <summary>
        ///       Permet l'ajout d'un quizz dans la base de données.
        /// </summary>
        /// <param name="quizz">Quizz à ajouter.</param>
        /// <returns>L'identifiant du quizz ajouté.</returns>
        public async Task<int> AddAsync(Quizz quizz)
        {
            this.context.Quizzs.Add(quizz);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return quizz.QuizzId;
        }

        /// <summary>
        ///       Permet la mise à jour d'un quizz dans la base de données.
        /// </summary>
        /// <param name="quizz">Quizz à mettre à jour.</param>
        /// <returns>Le quizz modifié.</returns>
        public async Task<Quizz> UpdateAsync(Quizz quizz)
        {
            var quizzToUpdate = this.context.Quizzs.AsQueryable().FirstOrDefault(q => q.QuizzId == quizz.QuizzId);

            if (quizzToUpdate != null)
            {
                quizzToUpdate.CandidatId = quizz.CandidatId;
                quizzToUpdate.Candidat = quizz.Candidat;
                quizzToUpdate.NbQuestion = quizz.NbQuestion;
                quizzToUpdate.QuizzModule = quizz.QuizzModule;
                quizzToUpdate.QuizzQuestion = quizz.QuizzQuestion;
                quizzToUpdate.Chrono = quizz.Chrono;
                quizzToUpdate.Url = quizz.Url;
            }

            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return quizz;
        }

        /// <summary>
        ///       Permet la suppression d'un quizz de la base de données.
        /// </summary>
        /// <param name="quizzId">Identifiant du quizz à supprimer.</param>
        public async Task<bool> DeleteAsync(int quizzId)
        {
            var quizzToDelete = this.context.Quizzs.AsQueryable().FirstOrDefault(q => q.QuizzId == quizzId);
            if (quizzToDelete != null)
            {
                this.context.Quizzs.Remove(quizzToDelete);
                var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

                return result > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
