using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SafeAutoExercise.Application;
using SafeAutoExercise.Dtos;

namespace SafeAutoExercise.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {

        private readonly ILogger<DriversController> _logger;
        private readonly IDriverApp _service;

        public DriversController(ILogger<DriversController> logger, IDriverApp service )
        {
            _logger = logger;
             _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DriverReadDto>> GetAllDrivers()
        {
            var driverItems = _service.GetAllDrivers();
            
            return Ok(driverItems);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<DriverReadDto>> GetDriver(int id)
        {
            var driverItems = _service.GetDriver(id);
            if (driverItems != null)
                return Ok(driverItems);
            else
                return NotFound();
        }

        [HttpGet("report")]
        public ActionResult<IEnumerable<DriverReadDto>> GetDriversReport()
        {
            var driversReportItems = _service.GetDriversReport();
            if (driversReportItems != null)
                return Ok(driversReportItems);
            else
                return NotFound();
        }
    }
}
