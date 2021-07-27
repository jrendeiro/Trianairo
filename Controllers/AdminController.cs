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

        [HttpPut("/admin/{saintName}")]
        public IActionResult Put(Saint saint)
        {
            // var deleteSaint = _context.Saints.FirstOrDefault(s => s.name == saint.name);

            // _context.Saints.Remove(deleteSaint);

            // _context.Saints.Add(saint);

            // _context.SaveChanges();

            _context.Entry(saint).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok();

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

            // this works using the parameter in the url (alternative to what you have below with [FromBody])
        [HttpDelete("/admin/{saintName}")]
        public IActionResult Delete(string saintName)
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

        // [HttpDelete]
        // public IActionResult Delete([FromBody] string saintName)
        // {
        //     try
        //     {
        //         if (saintName != null) {
        //         var deleteSaint = _context.Saints
        //                             .Where(s => s.name == saintName)
        //                             .FirstOrDefault();

        //         _context.Saints.Remove(deleteSaint);

        //         _context.SaveChanges();
        //         }
        //     }
        //     catch (Exception ex)
        //     {
        //         error = ex.Message;
        //     }

        //     return Ok(error);
        // }

    }
}
