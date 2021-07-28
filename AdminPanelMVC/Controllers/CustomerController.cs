using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService _customerService;
        private IUserService _userService;
        public CustomerController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }
        public IActionResult Index()
        {
            var customers = _customerService.GetAllCustomerDetail().Data;
            return View(customers);
        }
        [HttpGet]
        public ActionResult AddCustomer()
        {
            List<SelectListItem> valueUser = (from x in _userService.GetAll().Data
                                               select new SelectListItem
                                               {
                                                   Text = x.FirstName+" "+x.LastName,
                                                   Value = x.UserId.ToString()
                                               }).ToList();
            ViewBag.vlu = valueUser;
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            _customerService.Add(customer);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditCustomer(int id)
        {
            List<SelectListItem> valueUser = (from x in _userService.GetAll().Data
                                              select new SelectListItem
                                              {
                                                  Text = x.FirstName + " " + x.LastName,
                                                  Value = x.UserId.ToString()
                                              }).ToList();
            ViewBag.vlu = valueUser;
            var customerToUpdate = _customerService.GetCustomerById(id).Data;
            return View(customerToUpdate);
        }
        [HttpPost]
        public ActionResult EditCustomer(Customer customer)
        {
            _customerService.Update(customer);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCustomer(int id)
        {
            var customerToDelete = _customerService.GetCustomerById(id).Data;
            _customerService.Delete(customerToDelete);
            return RedirectToAction("Index");

        }
    }
}
