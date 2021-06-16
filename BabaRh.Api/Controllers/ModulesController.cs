
using BabaRh.AccessLayer.EntityFramework.AccessLayers;
using BabaRh.Api.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BabaRh.Api.Controllers
{
    public class ModulesController : ApiController
    {
        private readonly ModuleAccessLayer moduleAccessLayer = ModuleAccessLayer.Instance;
       

        // GET api/modules
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = moduleAccessLayer.GetAll().Select(m => new Module
            {
                ModuleId = m.ModuleId,
                ModuleLib = m.ModuleLib
            }); 

            return this.Ok(result);
        }


        // GET api/modules/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = moduleAccessLayer.Get(id);

            if (fromDb == null)
                return this.NotFound();

            var result = new Module
            {
                ModuleId = fromDb.ModuleId,
                ModuleLib = fromDb.ModuleLib,
            };

            return this.Ok(result);
        }
                        

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Module module)
        {
            
            var moduleToAdd = new AccessLayer.Models.Module
            {
                ModuleLib = module.ModuleLib
            };

            
            await moduleAccessLayer.AddAsync(moduleToAdd);
            return this.Ok("created");
        }


    
        [HttpPut]
        public async Task<IHttpActionResult> UpdateAsync([FromBody] Module module)
        {
            var moduleToUpdate = new AccessLayer.Models.Module
            {
                ModuleId = module.ModuleId,
                ModuleLib = module.ModuleLib
            };

            await moduleAccessLayer.UpdateAsync(moduleToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var moduleToDelete = moduleAccessLayer.Get(id);

            if (moduleToDelete == null)
            {
                return this.NotFound();
            }

            await moduleAccessLayer.DeleteAsync(moduleToDelete.ModuleId);
            return this.Ok("Delete");
        }

    }
}
