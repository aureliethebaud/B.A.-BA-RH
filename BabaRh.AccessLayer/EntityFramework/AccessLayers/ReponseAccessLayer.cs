namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
    using BabaRh.AccessLayer.EntityFramework.Interfaces;
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class ReponseAccessLayer : IReponseAccessLayer
    {
        private readonly BabaRhDbContext context;

        private static ReponseAccessLayer instance;
        public static ReponseAccessLayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new ReponseAccessLayer();

                return instance;
            }

        }
        private ReponseAccessLayer()
        {
            this.context = new BabaRhDbContext();
        }


        /// <summary>
        ///       Permet l'ajout d'une réponse dans la base de données.
        /// </summary>
        /// <param name="reponse">Réponse à ajouter.</param>
        /// <returns>L'identifiant de la réponse ajoutée.</returns>
        public async Task<int> AddAsync(Reponse reponse)
        {
            this.context.Reponses.Add(reponse);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return reponse.ReponseId;
        }


        /// <summary>
        ///       Permet la mise à jour d'une réponse dans la base de données.
        /// </summary>
        /// <param name="reponse">Réponse à mettre à jour.</param>
        /// <returns>La réponse modifiée.</returns>
        public async Task<bool> UpdateAsync(Reponse reponse)
        {
            var reponseToUpdate = this.context.Reponses.FirstOrDefault(r => r.ReponseId == reponse.ReponseId);

            if (reponse == null)
                return false;

            reponseToUpdate.ReponseLib = reponse.ReponseLib;
            reponseToUpdate.IsOk = reponse.IsOk;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }


        /// <summary>
        ///       Permet la suppression d'une réponse de la base de données.
        /// </summary>
        /// <param name="reponseId">Identifiant de la réponse à supprimer.</param>
        public async Task<bool> DeleteAsync(int reponseId)
        {
            var reponseToDelete = this.Get(reponseId);
            if (reponseToDelete != null)
            {
                this.context.Reponses.Remove(reponseToDelete);
                this.context.SaveChanges();

                var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

                return result > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///       Permet de retourner une réponse de la base de données.
        /// </summary>
        /// <param name="reponseId">Identifiant de la réponse à retourner.</param>
        /// <returns>La réponse retournée.</returns>
        public Reponse Get(int reponseId)
        {
            return this.context.Reponses.AsQueryable().SingleOrDefault(x => x.ReponseId == reponseId);
        }



        /// <summary>
        ///       Permet de retourner toutes les réponses de la base de données.
        /// </summary>
        /// <returns>La liste des réponses retournée.</returns>
        public List<Reponse> GetAll()
        {
            return this.context.Reponses.AsQueryable().ToList();
        }

    }
}
