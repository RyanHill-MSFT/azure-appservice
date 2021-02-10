using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LCARS.Database.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LCARS.Interface.Padd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalLogsController : ControllerBase
    {
        private readonly CoreContext _context;
        private readonly ILogger<PersonalLogsController> _logger;

        public PersonalLogsController(CoreContext context, ILogger<PersonalLogsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/PersonalLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personal>>> GetPersonalLogs()
        {
            return await _context.PersonnelLogs.ToListAsync();
        }

        // GET: api/PersonalLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Personal>> GetPersonalLog(int id)
        {
            var personalLog = await _context.PersonnelLogs.FindAsync(id);

            if (personalLog == null)
            {
                return NotFound();
            }

            return personalLog;
        }

        // PUT: api/PersonalLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalLog(int id, Personal personalLog)
        {
            if (id != personalLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalLogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonalLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Personal>> PostPersonalLog(Personal personalLog)
        {
            _logger.LogInformation("Recording personal log");
            _context.PersonnelLogs.Add(personalLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonalLog), new { id = personalLog.Id }, personalLog);
        }

        // DELETE: api/PersonalLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalLog(int id)
        {
            var personalLog = await _context.PersonnelLogs.FindAsync(id);
            if (personalLog == null)
            {
                return NotFound();
            }

            _logger.LogInformation($"Deleting personal log {id} from {personalLog?.Officer}'s database");
            _context.PersonnelLogs.Remove(personalLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalLogExists(int id)
        {
            return _context.PersonnelLogs.Any(e => e.Id == id);
        }
    }
}
