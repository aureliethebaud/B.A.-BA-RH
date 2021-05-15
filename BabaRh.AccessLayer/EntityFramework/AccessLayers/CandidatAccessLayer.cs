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
        public int Add(Candidat candidat)
        {
            this.context.Candidats.Add(candidat);
            this.context.SaveChanges();

            return candidat.CandidatId;
        }


        /// <summary>
        ///       Permet la mise à jour d'un candidat dans la base de données.
        /// </summary>
        /// <param name="candidat">Candidat à mettre à jour.</param>
        /// <returns>Le candidat modifié.</returns>
        public Candidat Update(Candidat candidat)
        {
            var candidatToUpdate = this.Get(candidat.CandidatId);

            if (candidatToUpdate != null)
            {
                candidatToUpdate.Nom = candidat.Nom;
                candidatToUpdate.Prenom = candidat.Prenom;
            }

            this.context.SaveChanges();

            return candidat;
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
