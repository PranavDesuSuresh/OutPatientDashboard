using Microsoft.EntityFrameworkCore;
using OutPatientDashboard.Service.Models;
using System.Collections.Generic;

namespace OutPatientDashboard.Service.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Physician> Physician { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<StatusType> StatusType { get; set; }

    }
}
