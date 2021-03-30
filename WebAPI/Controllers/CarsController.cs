using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Entities.DTOs;

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
       // [Authorize(Roles ="car.getall")]
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
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _iCarService.GetCarsByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
             return BadRequest(result.Message);       
            }
            
        }
        [HttpGet("getcarbybrandid")]
        public IActionResult GetCarByBrandId(int brandId)
        {
            var result = _iCarService.GetCarByBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }
        [HttpGet("getcarbycolorid")]
        public IActionResult GetByColorId(int colorId)
        {
            var result = _iCarService.GetCarByColorId(colorId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }
        [HttpGet("getallcardetails")]
        public IActionResult GetAllCarDetails()
        {
            var result = _iCarService.GetAllCarDetails();
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpGet("getcardetail")]
        public IActionResult GetCarDetail(int carId)
        {
            var result = _iCarService.GetCarDetails(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpGet("getcardetailimage")]
        public IActionResult GetCarDetailAndImage(int carId)
        {
            var result = _iCarService.GetCarDetailImage(carId);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("caradd")]
        public IActionResult Add(Car car)
        {
            var result = _iCarService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }

        }
        [HttpGet("getcarsdetails")]
        public IActionResult GetCarsDetails([FromQuery] CarDetailFilterDto filterDto)
        {
            var result = _iCarService.GetCarsDetails(filterDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



















    }
}
