using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class Patient
    {
        [Key]
        public int Patient_id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        List<Doctor> doctors { get; set; } = new();

    }
}
