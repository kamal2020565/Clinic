using System.ComponentModel.DataAnnotations;

namespace Clinic.Models
{
    public class DO_pa
    {
        [Key]
        public int id_doctor { get; set; }
        public int id_patient { get; set; }
        public DateTime DateTime { get; set; }
        public string Name { get; set; }
        List<Doctor> doctors { get; set; }
        List<Patient> patients {  get; set; }  
    }
    
}
