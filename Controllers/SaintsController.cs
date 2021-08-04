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
using System.ComponentModel;

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

        [HttpGet("/saintsapi/{property}/{order}")]
        public IEnumerable<SaintDto> GetSaints(string property, Order order)
        {
            // var saints = _context.Saints.ToList();

            PropertyDescriptor prop = TypeDescriptor.GetProperties(typeof(Saint)).Find(property, true);


            var saints = order == 
                        Order.Ascending ? _context.Saints.ToList().OrderBy(x => prop.GetValue(x))
                                        : _context.Saints.ToList().OrderByDescending(x => prop.GetValue(x));

            // SYNTAX for parameterized ordering with queryables: OrderBy("Make ASC, Year DESC")
            // ref: https://stackoverflow.com/questions/41244/dynamic-linq-orderby-on-ienumerablet-iqueryablet
            // var saints = _context.Saints.AsQueryable().OrderBy($"{field} {orderby}").ToArray();
            // var saints = _context.Saints.AsQueryable().ToArray().OrderByDescending(s => s.latestEvent);

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
                    .FirstOrDefault(s => s.name.Contains(saintName));

            return Ok(saint);
        }

    }
}
