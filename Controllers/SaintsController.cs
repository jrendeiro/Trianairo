using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Trianairo.Data;

namespace Trianairo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaintsApiController : ControllerBase
    {
        private readonly ILogger<SaintsApiController> _logger;
        private readonly DataContext _context;

        public SaintsApiController(ILogger<SaintsApiController> logger, DataContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<Saint> Get()
        {
            return _context.Saints.OrderBy(s => s.name).ToArray();
        }
        [HttpGet("/saintsapi/{saintName}")]

        public Saint Get(string saintName)
        {
            return _context.Saints
                    .FirstOrDefault(s => s.name == saintName);
        }
        
    }
}
