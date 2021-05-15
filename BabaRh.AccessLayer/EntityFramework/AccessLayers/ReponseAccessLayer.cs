using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
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
        public int Add(Reponse reponse)
        {
            this.context.Reponses.Add(reponse);
            this.context.SaveChanges();

            return reponse.ReponseId;
        }


        /// <summary>
        ///       Permet la mise à jour d'une réponse dans la base de données.
        /// </summary>
        /// <param name="reponse">Réponse à mettre à jour.</param>
        /// <returns>La réponse modifiée.</returns>
        public Reponse Update(Reponse reponse)
        {
            var reponseToUpdate = this.Get(reponse.ReponseId);

            if (reponseToUpdate != null)
            {
                reponseToUpdate.ReponseLib = reponse.ReponseLib;
                reponseToUpdate.IsOk = reponse.IsOk;
            }

            this.context.SaveChanges();

            return reponse;
        }


        /// <summary>
        ///       Permet la suppression d'une réponse de la base de données.
        /// </summary>
        /// <param name="reponseId">Identifiant de la réponse à supprimer.</param>
        public void Delete(int ReponseId)
        {
            var reponseToDelete = this.Get(ReponseId);
            if (reponseToDelete != null)
            {
                this.context.Reponses.Remove(reponseToDelete);
                this.context.SaveChanges();
            }
            else
            {
                throw new Exception("La réponse n'existe pas");
            }
        }

        /// <summary>
        ///       Permet de retourner une réponse de la base de données.
        /// </summary>
        /// <param name="reponseId">Identifiant de la réponse à retourner.</param>
        /// <returns>La réponse retournée.</returns>
        public Reponse Get(int reponseId)
        {
            return this.context.Reponses.SingleOrDefault(x => x.ReponseId == reponseId);
        }



        /// <summary>
        ///       Permet de retourner toutes les réponses de la base de données.
        /// </summary>
        /// <returns>La liste des réponses retournée.</returns>
        public List<Reponse> GetAll()
        {
            return this.context.Reponses.ToList();
        }

    }
}

