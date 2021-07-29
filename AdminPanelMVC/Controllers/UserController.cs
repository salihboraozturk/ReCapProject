using Business.Abstract;
using Core.Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelMVC.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var users = _userService.GetAll().Data;
            return View(users);
        }
        [HttpGet]
        public ActionResult EditUser(int id)
        {
            var userToUpdate = _userService.GetUserById(id).Data;
            return View(userToUpdate);
        }
        [HttpPost]
        public ActionResult EditUser(User user)
        {
            _userService.UserUpdate(user);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteUser(int id)
        {
            var userToDelete = _userService.GetUserById(id).Data;
            _userService.Delete(userToDelete);
            return RedirectToAction("Index");

        }
    }
}
