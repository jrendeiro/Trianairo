
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Trianairo.Data;

namespace Trianairo.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly DataContext _context;
        public LoginController(ILogger<LoginController> logger, DataContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet("/login/{id}")]
        public bool GetLogin(string id)
        {
            bool result;
            return result = id == "45bdf35bb27e96d7";
        }
    }
}