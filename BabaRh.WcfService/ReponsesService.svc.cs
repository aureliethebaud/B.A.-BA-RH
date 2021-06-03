using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BabaRh.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "ReponsesService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez ReponsesService.svc ou ReponsesService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class ReponsesService : IReponsesService
    {
        private readonly IReponseAccessLayer reponseAccessLayer;
        public ReponsesService()
        {
            this.reponseAccessLayer = ReponseAccessLayer.Instance;
        }

        public int AddReponse(AjoutReponse reponse)
        {
            if (this.reponseAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (reponse == null)
            {
                throw new Exception("L'objet ajouté ne peut pas être null");
            }

            return this.reponseAccessLayer.Add(new Reponse
            {
                ReponseId = reponse.ReponseId,
                ReponseLib = reponse.ReponseLib,
                IsOk = reponse.IsOk,
                QuestionId = reponse.QuestionId

            });
        }

        public bool DeleteReponse(int ReponseId)
        {
            if (this.reponseAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }
            if (ReponseId <= 0)
            {
                return false;
            }
            this.reponseAccessLayer.Delete(ReponseId);
            return true;
        }

        public ReponseOutput GetReponse(int ReponseId)
        {
            if (this.reponseAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (ReponseId <= 0)
            {
                throw new Exception("L'id n'est pas au format attendu");
            }

            var reponseUpdated = this.reponseAccessLayer.Get(ReponseId);

            return reponseUpdated != null ? this.TransformReponseToReponseOutput(reponseUpdated) : null;
        }

        public List<ReponseOutput> GetReponses()
        {
            if (this.reponseAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            var reponses = this.reponseAccessLayer.GetAll();
            var reponsesReturned = new List<ReponseOutput>();


            foreach (var x in reponses)
            {
                reponsesReturned.Add(this.TransformReponseToReponseOutput(x));
            }

            return reponsesReturned;
        }

        public ReponseOutput UpdateReponse(UpdateReponseInput reponse)
        {
            if (this.reponseAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (reponse == null)
            {
                throw new Exception("Impossible de réaliser l'update d'une ressource nulle");
            }

            var reponseUpdated = this.reponseAccessLayer.Update(new Reponse()
            {
                ReponseId = reponse.ReponseId,
                ReponseLib = reponse.ReponseLib,
                IsOk = reponse.IsOk,
                QuestionId = reponse.QuestionId
            });

            return this.TransformReponseToReponseOutput(reponseUpdated);
        }

        private ReponseOutput TransformReponseToReponseOutput(Reponse r)
        {
            return new ReponseOutput
            {
                ReponseId = r.ReponseId,
                ReponseLib = r.ReponseLib,
                IsOk = r.IsOk,
                QuestionId = r.QuestionId
            };
        }
    }
}

