using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace AdminPanelMVC.Controllers
{
    public class BrandController : Controller
    {
        //private readonly BrandManager brandManager = new BrandManager(new EfBrandDal());
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            var brands = _brandService.GetAll().Data;
            return View(brands);
        }
        [HttpGet]
        public ActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBrand(Brand brand)
        {
            _brandService.Add(brand);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditBrand(int id)
        {
            var brandToUpdate = _brandService.GetBrandById(id).Data;
            return View(brandToUpdate);
        }
        [HttpPost]
        public ActionResult EditBrand(Brand brand)
        {
            _brandService.Update(brand);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteBrand(int id)
        {
            var brandToDelete = _brandService.GetBrandById(id).Data;
            _brandService.Delete(brandToDelete);
            return RedirectToAction("Index");

        }
    }
}
