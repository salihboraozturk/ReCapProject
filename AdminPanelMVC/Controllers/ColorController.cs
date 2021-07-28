using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelMVC.Controllers
{
    public class ColorController : Controller
    {
        private IColorService _colorService;
        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }
        public IActionResult Index()
        {
            var colors = _colorService.GetAll().Data;
            return View(colors);
        }
        [HttpGet]
        public ActionResult AddColor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddColor(Color color)
        {
            _colorService.Add(color);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditColor(int id)
        {
            var colorToUpdate = _colorService.GetColorById(id).Data;
            return View(colorToUpdate);
        }
        [HttpPost]
        public ActionResult EditColor(Color color)
        {
            _colorService.Update(color);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteColor(int id)
        {
            var colorToDelete = _colorService.GetColorById(id).Data;
            _colorService.Delete(colorToDelete);
            return RedirectToAction("Index");

        }
    }
}
