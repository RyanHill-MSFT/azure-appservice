using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using LCARS.Command.Processor.Chi._48.Models;
using Microsoft.Azure.Mobile.Server.Config;

namespace LCARS.Command.Processor.Chi._48.Controllers
{
    [MobileAppController]
    public class PersonalLogApiController : ApiController
    {
        private readonly DatabankContext _context;

        public PersonalLogApiController()
        {
            _context = new DatabankContext();
        }

        [Route("logs/personal")]
        public async Task<IHttpActionResult> GetPersonalLogs() =>  Ok(await _context.PersonLogs.ToListAsync());

        [Route("logs/personal/{id}")]
        public async Task<IHttpActionResult> GetPersonalLog(int id)
        {
            var personalLog = await _context.PersonLogs.FindAsync(id);
            if(personalLog == null)
            {
                return NotFound();
            }

            return Ok(personalLog);
        }
    }
}