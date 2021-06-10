using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    }
}
