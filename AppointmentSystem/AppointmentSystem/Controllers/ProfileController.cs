using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentSystem.Data;
using AppointmentSystem.Data.Entity;
using AppointmentSystem.Models;
using Korzh.EasyQuery.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ProfileController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public IActionResult Index(string param = null)
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);

            if (user == null)
            {
                return View("Error");
            }
            if (_userManager.IsInRoleAsync(user, "Admin").Result)
            {
                var appo = param is null ?
                    _context.Appointments.ToList() :
                    _context.Appointments.Where(ap => ap.Plaka.Contains(param) || ap.Name.Contains(param)).ToList();
                foreach (var item in appo)
                {
                    var appoUser = item.User;
                }
                AdminViewModel model = new AdminViewModel()
                {
                    User = user,
                    Appointment = appo,
                    GalleryUsers = appo,
                    GalleryUsersSelectList = appo.Select(n => new SelectListItem
                    {
                        //Value = appo.Id,
                        Text = $" {n.Name} {n.Surname}"
                    }).ToList()
                };
                return View("Admin", model);
            }
            return View();
        }
       public IActionResult getTable(string param)
        {
            AppUser user = _userManager.Users.SingleOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
            var appo = param is null ?
                    _context.Appointments.ToList() :
                    _context.Appointments.Where(ap => ap.Plaka.Contains(param) || ap.Name.Contains(param) ).ToList();
            foreach (var item in appo)
            {
                var appoUser = item.User;
            }
            AdminViewModel model = new AdminViewModel()
            {
                User = user,
                Appointment = appo,
               
            };
            return View("getTable", model);
        }
      
       

    }
}