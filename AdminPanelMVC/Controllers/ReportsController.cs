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
        public ReportsController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            var carsDetails = _carService.GetAllCarDetails().Data;
            return View(carsDetails);
        }
    }
}
