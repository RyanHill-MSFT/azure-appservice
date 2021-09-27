using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LCARS.Core;
using LCARS.Core.Data.Crew;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LCARS.Command.Processor.Delta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficersController : ControllerBase
    {
        private readonly LcarsDatabase _context;
        private readonly ILogger<OfficersController> _logger;

        public OfficersController(LcarsDatabase context, ILogger<OfficersController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Officer>>> GetAsync() => await _context.Officers.ToListAsync();

        [HttpGet("{serialNo}")]
        public async Task<ActionResult<Officer>> GetBySerialNoAsync(string serialNo)
        {
            var officer = await _context.Officers.FindAsync(serialNo);
            if(officer == null)
            {
                return NotFound();
            }

            return officer;
        }

        [HttpPost]
        public async Task<ActionResult<Officer>> PostAsync(Officer officer)
        {
            _context.Officers.Add(officer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBySerialNoAsync), new { serialNo = officer.SerialNo }, officer);
        }
    }
}
