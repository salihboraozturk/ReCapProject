using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _iCarService;
        public CarsController(ICarService iCarService)
        {
            _iCarService = iCarService;
        }
       
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _iCarService.GetAll();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getbybrandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _iCarService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
             return BadRequest(result.Message);       
            }
            
        }
        [HttpGet("getbycolorid")]
        public IActionResult GetByColorId(int id)
        {
            var result = _iCarService.GetCarsByColorId(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }
        [HttpGet("getcardetails")]
        public IActionResult GetCarDetails()
        {
            var result = _iCarService.GetCarDetails();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("caradd")]
        public IActionResult Add(Car car)
        {
            var result = _iCarService.Add(car);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }
        


















    }
}
