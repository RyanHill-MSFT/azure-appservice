using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using LCARS.Command.Processor.Chi._48.Models;
using Microsoft.Azure.Mobile.Server.Config;

namespace LCARS.Command.Processor.Chi._48.Controllers
{
    [MobileAppController]
    public class CrewController : ApiController
    {
        private readonly DatabankContext _context;

        public CrewController()
        {
            _context = new DatabankContext();
        }

        public async Task<IHttpActionResult> GetAll() => Ok(await _context.Officers.ToListAsync());

        public async Task<IHttpActionResult> GetByAssignment(string vessel)
        {
            var crewQuery = from c in _context.Officers
                            where c.Assignment == vessel
                            select c;

            var crew = await crewQuery.ToListAsync();
            if (!crew.Any())
            {
                return NotFound();
            }

            return Ok(crew);
        }
    }
}
