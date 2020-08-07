using AppointmentSystem.Data.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }
       
        [Required(ErrorMessage = "Lütfen Soyadınızı Belirtiniz.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen ilinizi belirtiniz.")]
        
        public string il { get; set; }
        [Required(ErrorMessage = "Lütfen plakanızı belirtiniz.")]
        
        public string Plaka { get; set; }
        [Required(ErrorMessage = "Lütfen telefon numaranızı belirtiniz.")]
        
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adını belirtiniz.")]
        [Display(Name = "Kullanıcı Adınız:")]
        public string Name { get; set; }
       
        
        public string CarName { get; internal set; }
        [Required(ErrorMessage = "Lütfen arabanızın model yılını belirtiniz.")]
       
        public string CarModel { get; internal set; }
        [Required(ErrorMessage = "Lütfen başlangıç tarihini belirtiniz.")]
        
        public DateTime StartDate { get; internal set; }
        [Required(ErrorMessage = "Lütfen randevu bitiş tarihini belirtiniz.")]
        
      
        
        public string Description { get; internal set; }
        public string UserId { get; internal set; }
       

      
    }
}