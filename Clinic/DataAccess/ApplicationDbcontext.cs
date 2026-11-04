using Clinic.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinic.DataAccess
{
    public class ApplicationDbcontext:DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        DbSet<Patient> Patients { get; set; } 
       public DbSet<DO_pa>Do_pa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Clinic;Integrated Security=True;Connect" +
                " Timeout=30;Encrypt=True;Trust Server Certificate=True;");
        }

    }
}
