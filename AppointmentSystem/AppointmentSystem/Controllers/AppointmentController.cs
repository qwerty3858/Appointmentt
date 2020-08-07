using System;

using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppointmentSystem.Data;
using AppointmentSystem.Data.Entity;
using AppointmentSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace AppointmentSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _context;
        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Register()
        {
            var cityList = _context.Cities.ToList();
            AddOrUpdateAppointmentModel model = new AddOrUpdateAppointmentModel()
            {
            City = cityList.Select(n => new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = $" {n.Name} "
                }).ToList()
            };
            return View(model);

        }
        
        public JsonResult GetAppointments()
        {
            var model = _context.Appointments
              .Select(x => new AppointmentViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Surname = x.Surname,
                    Plaka = x.Plaka,
                    il = x.il,
                    PhoneNumber = x.PhoneNumber,
                
                    CarName = x.CarName,
                    CarModel = x.CarModel,
                    StartDate = x.StartDate,
                   
                    Description = x.Description
                    
                });

            return Json(model);
        }
        public JsonResult GetAppointmentsByUser(string userId = "")
        {
            var model = _context.Appointments.Where(x => x.UserId == userId)
              .Select(x => new AppointmentViewModel()
                {
                    Surname = x.Surname,
                    PhoneNumber = x.PhoneNumber,
                    Plaka = x.Plaka,
                    il = x.il,
                    Id = x.Id,
                    
                    CarName = x.CarName,
                    CarModel = x.CarModel,
                    StartDate = x.StartDate,
                   
                    Description = x.Description,
                    Name = x.Name,
                    UserId = x.UserId
                });

            return Json(model);
        }
        [HttpPost]
        public JsonResult AddOrUpdateAppointment(AddOrUpdateAppointmentModel model)
        {
            
            //Validasyon
            if (model.Id == 0)
            {
            //    var check = _context.Appointments.Where(x => x.StartDate == model.StartDate && x.EndDate == model.EndDate);
            //if (check != null)
            //{
            //    return Json("Error");
                    
            //}
                Appointment entity = new Appointment()
                {
                    Surname = model.Surname,
                    PhoneNumber = model.PhoneNumber,
                    Plaka = model.Plaka,
                    il = model.il,
                    Name = model.Name,
                    CreatedDate = DateTime.Now,
                    StartDate = model.StartDate, 
                    Id=model.Id,
                    CarName = model.CarName,
                    CarModel = model.CarModel,
                    Description = model.Description,
                  
                };
               
                _context.Add(entity);
                _context.SaveChanges();
            }
            else
            {
                var entity = _context.Appointments.SingleOrDefault(x => x.Id == model.Id);
                if (entity == null)
                {
                    return Json("Güncellenecek veri bulunamadı.");
                }
                entity.Surname = model.Surname;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Plaka = model.Plaka;
                entity.il = model.il;
                entity.Name = model.Name;
                entity.UpdatedDate = DateTime.Now;
                entity.CarName = model.CarName;
                entity.CarModel = model.CarModel;
                entity.Description = model.Description;
                entity.StartDate = model.StartDate;
           
                entity.UserId = model.UserId;

                _context.Update(entity);
                _context.SaveChanges();
            }

            return Json("200");
        }
      
        public JsonResult DeleteAppointment(int id = 0)
        {
            var entity = _context.Appointments.SingleOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return Json("Kayıt bulunamadı.");
            }
            _context.Remove(entity);
            _context.SaveChanges();
            return Json("200");
        }
    }
}