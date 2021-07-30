using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelMVC.Controllers
{
    public class ChartController : Controller
    {
        private ICarService _carService;
        public ChartController(ICarService carService)
        {
            _carService = carService;
        }
        public ActionResult CarChart()
        {
            return View();
        }
        public IActionResult CarChartInitial()
        {
            return Json(CarChartList());
        }
        public List<ListChartModel> CarChartList()
        {
            return _carService.GetCarCountGraph().Data;
        }
        public ActionResult BrandChart()
        {
            return View();
        }
        public IActionResult BrandChartInitial()
        {
            return Json(BrandChartList());
        }
        public List<ListChartModel> BrandChartList()
        {
            return _carService.GetBrandCountGraph().Data;
        }
        public ActionResult ColorChart()
        {
            return View();
        }
        public IActionResult ColorChartInitial()
        {
            return Json(ColorChartList());
        }
        public List<ListChartModel> ColorChartList()
        {
            return _carService.GetColorCountGraph().Data;
        }
    }
}
