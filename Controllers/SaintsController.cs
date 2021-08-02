using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Trianairo.Data;

namespace Trianairo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaintsApiController : ControllerBase
    {
        private readonly ILogger<SaintsApiController> _logger;
        private readonly DataContext _context;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public SaintsApiController(ILogger<SaintsApiController> logger, DataContext context,
            IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }
        public IEnumerable<Saint> Get()
        {
            var saints = _context.Saints.OrderBy(s => s.name).ToArray();


            foreach (Saint s in saints)
            {
                s.pictureUrl = _cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(150).Height(200).Crop("fill")).BuildUrl("Trianairo/" + s.pictureUrl);
            }
            return saints;


        }
        [HttpGet("/saintsapi/{saintName}")]

        public IActionResult Get(string saintName)
        {
            var saint = _context.Saints
                    .FirstOrDefault(s => s.name == saintName);
            
            return Ok(saint);
        }
        
    }
}
