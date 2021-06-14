using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
    public class CandidatAccessLayer : ICandidatAccessLayer
    {
        private readonly BabaRhDbContext context;

        private static CandidatAccessLayer instance;
        public static CandidatAccessLayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new CandidatAccessLayer();

                return instance;
            }

        }
        private CandidatAccessLayer()
        {
            this.context = new BabaRhDbContext();
        }


        /// <summary>
        ///       Permet l'ajout d'un candidat dans la base de données.
        /// </summary>
        /// <param name="candidat">Candidat à ajouter.</param>
        /// <returns>L'identifiant du candidat ajouté.</returns>
        public async Task<int> AddAsync(Candidat candidat)
        {
            this.context.Candidats.Add(candidat);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return candidat.CandidatId;
        }


        /// <summary>
        ///       Permet la mise à jour d'un candidat dans la base de données.
        /// </summary>
        /// <param name="candidat">Candidat à mettre à jour.</param>
        /// <returns>Le candidat modifié.</returns>
        public async Task<bool> UpdateAsync(Candidat candidat)
        {
            var candidatToEdit = this.context.Candidats.FirstOrDefault(c => c.CandidatId == candidat.CandidatId);

            if (candidat == null)
                return false;

            candidatToEdit.Nom = candidat.Nom;
            candidatToEdit.Prenom = candidat.Prenom;

            var result = await this.context.SaveChangesAsync().ConfigureAwait(false);

            return result > 0;
        }


        /// <summary>
        ///       Permet la suppression d'un candidat de la base de données.
        /// </summary>
        /// <param name="candidatId">Identifiant du candidat à supprimer.</param>
        public void Delete(int candidatId)
        {
            var candidatToDelete = this.Get(candidatId);
            if (candidatToDelete != null)
            {
                this.context.Candidats.Remove(candidatToDelete);
                this.context.SaveChanges();
            }
            else
            {
                throw new Exception("Le candidat n'existe pas");
            }
        }

        /// <summary>
        ///       Permet de retourner un candidat de la base de données.
        /// </summary>
        /// <param name="candidatId">Identifiant du candidat à retourner.</param>
        /// <returns>Le candidat retourné.</returns>
        public Candidat Get(int candidatId)
        {
            return this.context.Candidats.SingleOrDefault(x => x.CandidatId == candidatId);
        }



        /// <summary>
        ///       Permet de retourner tous les candidats de la base de données.
        /// </summary>
        /// <returns>La liste des candidats retournée.</returns>
        public List<Candidat> GetAll()
        {
            return this.context.Candidats.ToList();
        }

    }

    
}
