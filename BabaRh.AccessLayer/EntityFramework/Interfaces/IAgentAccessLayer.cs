namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    using BabaRh.AccessLayer.Models;
    using System.Collections.Generic;

    public interface IAgentAccessLayer
    {
        int Add(Agent agent);

        Agent Update(Agent agent);

        void Delete(int agentId);

        Agent Get(int agentId);

        List<Agent> GetAll();

    }
}
