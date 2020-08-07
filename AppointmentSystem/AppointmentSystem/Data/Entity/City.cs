using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentSystem.Data.Entity
{
    public class City
    {
        private ApplicationDbContext _context;
        public City(ApplicationDbContext context)
        {
            _context = context;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        
    }
}
