using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSystem.Data.Entity  
{
    public class Appointment
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Hour { get; set; }
        public DateTime UpdatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string Description { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public string il { get; set; }
        public string Plaka { get; set; }
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
    }
}
