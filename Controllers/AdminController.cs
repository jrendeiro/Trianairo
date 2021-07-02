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
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly DataContext _context;
        string error;

        public AdminController(ILogger<AdminController> logger, DataContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public IEnumerable<Saint> Get()
        {
            return _context.Saints.ToArray();
        }


        [HttpPost]
        public IActionResult Post(Saint saint)
        {
            try
            {
                _context.Add(saint);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return Ok(error);
        }

            //this works using the parameter in the url (alternative to what you have below with [FromBody])
        // [HttpDelete("/admin/{saint}")]
        // public IActionResult Delete(string saint)
        // {
        //     return Ok($"nice! your saint is {saint}");
        // }

        [HttpDelete]
        public IActionResult Delete([FromBody] string saintName)
        {
            try
            {
                if (saintName != null) {
                var deleteSaint = _context.Saints
                                    .Where(s => s.name == saintName)
                                    .FirstOrDefault();

                _context.Saints.Remove(deleteSaint);

                _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return Ok(error);
        }


    }
}
