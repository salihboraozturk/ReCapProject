using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.DTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminPanelMVC.Controllers
{
    public class CarController : Controller
    {
        private ICarService _carService;
        private IBrandService _brandService;
        private IColorService _colorService;
        private ICarImageService _carImageService;

        public CarController(ICarService carService, IBrandService brandService, IColorService colorService, ICarImageService carImageService)
        {
            _carService = carService;
            _brandService = brandService;
            _colorService = colorService;
            _carImageService = carImageService;
        }
        public IActionResult Index()
        {
            var cars = _carService.GetAllCarDetails().Data;
            return View(cars);
        }
        [HttpGet]
        public ActionResult EditCar(int id)
        {
            List<SelectListItem> valueBrand = (from x in _brandService.GetAll().Data
                                                  select new SelectListItem
                                                  {
                                                      Text = x.BrandName,
                                                      Value = x.BrandId.ToString()
                                                  }).ToList();
            List<SelectListItem> valueColor = (from x in _colorService.GetAll().Data
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ColorName,
                                                      Value = x.ColorId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueColor;
            ViewBag.vlb = valueBrand;
            var carToUpdate = _carService.GetCarById(id).Data;
            return View(carToUpdate);
        }
        [HttpPost]
        public ActionResult EditCar(Car car)
        {
            _carService.Update(car);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCar(int id)
        {
            var carToDelete = _carService.GetCarById(id).Data;
            var carImageToDelete = _carImageService.GetById(id).Data;
            _carImageService.Delete(carImageToDelete);
            _carService.Delete(carToDelete);
            return RedirectToAction("Index");

        }
    }
}
