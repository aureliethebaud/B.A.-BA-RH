using BabaRh.AccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaRh.AccessLayer.EntityFramework.Interfaces
{
    public interface IAgentAccessLayer
    {
        int Add(Agent agent);

        Agent Update(Agent agent);

        void Delete(int agentId);

        Agent Get(int agentId);

        List<Agent> GetAll();

    }
}
