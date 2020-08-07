using System;
using System.Collections.Generic;
using System.Text;
using AppointmentSystem.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AppointmentSystem.Models;
using AppointmentSystem;

namespace AppointmentSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<City> Cities { get; set; }



    }
}
