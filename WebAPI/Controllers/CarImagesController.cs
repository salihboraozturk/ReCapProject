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
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }
        [HttpPost("CarImageAdd")]
        public IActionResult Add([FromForm] CarImage carImage, [FromForm] IFormFile formFile) {
            var result=_carImageService.Add(carImage,formFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CarImageUpdate")]
        public IActionResult Update([FromForm] CarImage carImage, [FromForm] IFormFile formFile)
        {
            var result = _carImageService.Update(carImage, formFile);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallimagebycarid")]
        public IActionResult GetAllByCarId(int carId)
        {
            var result = _carImageService.GetAllImageByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
