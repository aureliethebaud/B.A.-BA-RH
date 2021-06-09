using BabaRh.AccessLayer.EntityFramework.Interfaces;
using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.AccessLayers
{
    public class AgentAccessLayer : IAgentAccessLayer
    {
        private readonly BabaRhDbContext context;

        private static AgentAccessLayer instance;
        public static AgentAccessLayer Instance
        {
            get
            {
                if (instance == null)
                    instance = new AgentAccessLayer();

                return instance;
            }

        }
        private AgentAccessLayer()
        {
            this.context = new BabaRhDbContext();
        }


        /// <summary>
        ///       Permet l'ajout d'un agent dans la base de données.
        /// </summary>
        /// <param name="agent">Agent à ajouter.</param>
        /// <returns>L'identifiant de l'agent ajouté.</returns>
        public int Add(Agent agent)
        {
            this.context.Agents.Add(agent);
            this.context.SaveChanges();

            return agent.AgentId;
        }


        /// <summary>
        ///       Permet la mise à jour d'un agent dans la base de données.
        /// </summary>
        /// <param name="agent">Agent à mettre à jour.</param>
        /// <returns>L'agent modifié.</returns>
        public Agent Update(Agent agent)
        {
            var agentToUpdate = this.Get(agent.AgentId);

            if (agentToUpdate != null)
            {
                agentToUpdate.Nom = agent.Nom != null ? agent.Nom : agentToUpdate.Nom;
                agentToUpdate.Prenom = agent.Prenom != null ? agent.Prenom : agentToUpdate.Prenom;
                agentToUpdate.Password = agent.Password != null ? agent.Password : agentToUpdate.Password;
            }

            this.context.SaveChanges();

            return agent;
        }


        /// <summary>
        ///       Permet la suppression d'un agent de la base de données.
        /// </summary>
        /// <param name="agentId">Identifiant de l'agent à supprimer.</param>
        public void Delete(int agentId)
        {
            var agentToDelete = this.Get(agentId);
            if (agentToDelete != null)
            {
                this.context.Agents.Remove(agentToDelete);
                this.context.SaveChanges();
            }
            else
            {
                throw new Exception("L'agent n'existe pas");
            }
        }

        /// <summary>
        ///       Permet de retourner un agent de la base de données.
        /// </summary>
        /// <param name="agentId">Identifiant de l'agent à retourner.</param>
        /// <returns>L'agent retourné.</returns>
        public Agent Get(int agentId)
        {
            return this.context.Agents.SingleOrDefault(x => x.AgentId == agentId);
        }



        /// <summary>
        ///       Permet de retourner tous les agents de la base de données.
        /// </summary>
        /// <returns>La liste des agents retournée.</returns>
        public List<Agent> GetAll()
        {
            return this.context.Agents.ToList();
        }
    }
}
