﻿
using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using BabaRh.Api.Models;
using System.Threading.Tasks;
using System.Web.Http;

namespace BabaRh.Api.Controllers
{
    public class ModulesController : ApiController
    {
        private readonly ModuleAccessLayer moduleAccessLayer = ModuleAccessLayer.Instance;
        private readonly QuestionAccessLayer questionAccessLayer = QuestionAccessLayer.Instance;

        // GET api/modules
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = moduleAccessLayer.GetAll();

            return this.Ok(result);
        }

        // GET api/modules/id
        [HttpGet]
        public IHttpActionResult Get(string moduleLib)
        {
            var result = moduleAccessLayer.Get(moduleLib);

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody] Module module)
        {
            
            var moduleToAdd = new AccessLayer.Models.Module
            {
                ModuleLib = module.ModuleLib
            };

            
            moduleAccessLayer.Add(moduleToAdd);
            return this.Ok("created");
        }

    }
}