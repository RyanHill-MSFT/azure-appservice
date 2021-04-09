using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using LCARS.Command.Processor.Chi._48.Models;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;

namespace LCARS.Command.Processor.Chi._48.Controllers
{
    public abstract class MobileTableControllerBase<TEntityData> : TableController<TEntityData> where TEntityData : class, ITableData
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileDatabankContext();
            DomainManager = new EntityDomainManager<TEntityData>(context, Request);
        }

        public IQueryable<TEntityData> GetAll() => Query();

        public SingleResult<TEntityData> Get(string id) => Lookup(id);

        public Task<TEntityData> Patch(string id, Delta<TEntityData> patch) => UpdateAsync(id, patch);

        public async Task<IHttpActionResult> Post(TEntityData data)
        {
            var current = await InsertAsync(data);
            return CreatedAtRoute("Tables", new { id = data.Id }, current);
        }

        public Task Delete(string id) => DeleteAsync(id);
    }
}