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
using System.Linq.Dynamic.Core;
using AutoMapper;

namespace Trianairo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaintsApiController : ControllerBase
    {
        private readonly ILogger<SaintsApiController> _logger;
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public SaintsApiController(ILogger<SaintsApiController> logger, DataContext context,
            IOptions<CloudinarySettings> cloudinaryConfig, IMapper mapper)
        {
            _cloudinaryConfig = cloudinaryConfig;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;

            Account acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(acc);
        }

        [HttpGet("/saintsapi/{field}/{orderby}")]
        public IEnumerable<SaintDto> GetSaints(string field, string orderby)
        {

            // SYNTAX: OrderBy("Make ASC, Year DESC")
            var saints = _context.Saints.AsQueryable().OrderBy($"{field} {orderby}").ToArray();

            foreach (Saint s in saints)
            {
                s.pictureUrl = _cloudinary.Api.UrlImgUp.Transform(new Transformation().Width(150).Height(200).Crop("fill")).BuildUrl("Trianairo/" + s.pictureUrl);
            }
            
            var saintsToReturn = _mapper.Map<IEnumerable<SaintDto>>(saints);
            
            return saintsToReturn;
        }
        [HttpGet("/saintsapi/{saintName}")]

        public IActionResult GetSaint(string saintName)
        {
            var saint = _context.Saints
                    .FirstOrDefault(s => s.name == saintName);
            
            return Ok(saint);
        }
        
    }
}
