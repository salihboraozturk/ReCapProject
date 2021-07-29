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
        public ReportsController(ICarService carService, IBrandService brandService)
        {
            _carService = carService;
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            var carsDetails = _carService.GetAllCarDetails().Data;
            return View(carsDetails);
        }
        public IActionResult Brand()
        {
            var brand = _brandService.GetAll().Data;
            return View(brand);
        }
    }
}
