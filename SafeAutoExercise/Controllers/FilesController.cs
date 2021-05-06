using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeAutoExercise.Application;
using SafeAutoExercise.Data;
using SafeAutoExercise.Models;

namespace SafeAutoExercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : ControllerBase
    {

        private readonly ILogger<FilesController> _logger;
        private readonly IFileDriverTrips _service;

        public FilesController(ILogger<FilesController> logger, IFileDriverTrips service )
        {
            _logger = logger;
             _service = service;
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                MemoryStream ms = new MemoryStream();


                if (file != null && file.Length > 0){
                file.CopyTo(ms);

                _service.UploadDriverTripsData(ms);

                
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
