
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSystem.Models
{
    public class AddOrUpdateAppointmentModel
    {
        [Required(ErrorMessage = "Lütfen adınızı belirtiniz.")]
        [Display(Name = "Adınız:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı belirtiniz.")]
        [Display(Name = "Soyadınız:")]
        public string Surname { get; set; }
       
        [Display(Name = "İl Seçiniz:")]
        public string il { get; set; }
        [Required(ErrorMessage = "Lütfen Plaka belirtiniz.")]
        [Display(Name = "Plaka Belirtiniz:")]
        public string Plaka { get; set; }
        [Required(ErrorMessage = "Lütfen Telefon No belirtiniz.")]
        [Display(Name = "Telefon Numarası:")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = "Lütfen tarihi belirtiniz.")]
        [Display(Name = "Randevu Tarihi:")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
       
        public string Hour { get; set; }
     
        public string CarName { get; set; }
        [Required(ErrorMessage = "Lütfen Model Yılı belirtiniz.")]
        [Display(Name = "Model Yılı :")]
        public string CarModel { get; set; }
        public string Description { get; set; }

        public IEnumerable<SelectListItem> City { get; set; }
}
}
