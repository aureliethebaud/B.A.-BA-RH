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
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "AgentsService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez AgentsService.svc ou AgentsService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class AgentsService : IAgentsService
    {
        private readonly IAgentAccessLayer agentAccessLayer;
        public AgentsService()
        {
            this.agentAccessLayer = AgentAccessLayer.Instance;
        }

        public int AddAgent(AjoutAgent agent)
        {
            if (this.agentAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (agent == null)
            {
                throw new Exception("L'objet ajouté ne peut pas être null");
            }

            return this.agentAccessLayer.Add(new Agent
            {
                Nom = agent.Nom,
                Prenom = agent.Prenom,
                Password = agent.Password
            });
        }

        public bool DeleteAgent(int AgentId)
        {
            if (this.agentAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }
            if (AgentId <= 0)
            {
                return false;
            }
            this.agentAccessLayer.Delete(AgentId);
            return true;
        }

        public AgentOutput GetAgent(int AgentId)
        {
            if (this.agentAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (AgentId <= 0)
            {
                throw new Exception("L'id n'est pas au format attendu");
            }

            var agentUpdated = this.agentAccessLayer.Get(AgentId);

            return agentUpdated != null ? this.TransformAgentToAgentOutput(agentUpdated) : null;
        }

        public List<AgentOutput> GetAgents()
        {
            if (this.agentAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            var agents = this.agentAccessLayer.GetAll();
            var agentsReturned = new List<AgentOutput>();

                        
            foreach (var x in agents)
            {
                agentsReturned.Add(this.TransformAgentToAgentOutput(x));
            }

            return agentsReturned;
        }

        public AgentOutput UpdateAgent(UpdateAgentInput agent)
        {
            if (this.agentAccessLayer == null)
            {
                throw new Exception("Une erreur s'est produite lors de la création du service");
            }

            if (agent == null)
            {
                throw new Exception("Impossible de réaliser l'update d'une ressource nulle");
            }

            var agentUpdated = this.agentAccessLayer.Update(new Agent()
            {
                AgentId = agent.AgentId,                
                Nom = agent.Nom,
                Prenom = agent.Prenom,
                Password = agent.Password
            });

            return this.TransformAgentToAgentOutput(agentUpdated);
        }

        private AgentOutput TransformAgentToAgentOutput(Agent a)
        {
            return new AgentOutput
            {
                AgentId = a.AgentId,
                Nom = a.Nom,
                Prenom = a.Prenom,
                Password = a.Password
            };
        }
    }
}

