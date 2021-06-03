using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BabaRh.WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IAgentsService" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IAgentsService
    {
        [OperationContract]
        int AddAgent(AjoutAgent agent);

        [OperationContract]
        bool DeleteAgent(int AgentId);

        [OperationContract]
        AgentOutput GetAgent(int AgentId);

        [OperationContract]
        List<AgentOutput> GetAgents();

        [OperationContract]
        AgentOutput UpdateAgent(UpdateAgentInput agent);
    }

    

    [DataContract]
    public class AgentBase
    {
        [DataMember]
        public int AgentId { get; set; }
        [DataMember]
        public string Nom { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Prenom { get; set; }
    }

    [DataContract]
    public class AjoutAgent : AgentBase
    {
    }

    [DataContract]
    public class AgentOutput : AgentBase
    {
    }

    [DataContract]
    public class UpdateAgentInput : AgentBase
    {
    }
}
