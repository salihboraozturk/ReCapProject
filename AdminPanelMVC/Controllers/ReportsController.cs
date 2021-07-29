using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelMVC.Controllers
{
    public class ReportsController : Controller
    {
        private ICarService _carService;
        private IBrandService _brandService;
        private IColorService _colorService;
        public ReportsController(ICarService carService, IBrandService brandService, IColorService colorService)
        {
            _carService = carService;
            _brandService = brandService;
            _colorService = colorService;
        }
        public IActionResult Car()
        {
            var carsDetails = _carService.GetAllCarDetails().Data;
            return View(carsDetails);
        }
        public IActionResult Brand()
        {
            var brand = _brandService.GetAll().Data;
            return View(brand);
        }
        public IActionResult Color()
        {
            var color = _colorService.GetAll().Data;
            return View(color);
        }
    }
}
