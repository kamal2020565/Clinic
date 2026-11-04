namespace Clinic.ViewModels
{
    public class DoctorWithSpVM

    {
        public Doctor Doctor { get; set; } =null!;
        public List<Doctor> Spdoctor { get;  set; }
        List<Doctor> doctorSP { get; set; } = null!;
    }
}
