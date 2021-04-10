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
        private readonly Databank _databank;
        private readonly ILogger<OfficersController> _logger;

        public OfficersController(Databank databank, ILogger<OfficersController> logger)
        {
            _databank = databank;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Officer>> GetAsync() => await _databank.Officers.ToListAsync();
    }
}
