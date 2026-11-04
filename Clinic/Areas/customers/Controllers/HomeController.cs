using System.Diagnostics;
using Azure;
using Clinic.DataAccess;
using Clinic.Models;
using Clinic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace Clinic.Areas.customers.Controllers
{
    [Area("customers")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationDbcontext dbcontext = new();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy(DoctorFilterVM doctorFilterVM,int page=1)
        {
            var Doctors = dbcontext.Doctors;
            //if(doctorFilterVM is not null)
            //{
            //    Doctors = Doctors.Where(e => e.Name.Contains(doctorFilterVM.Name));
            //}
            //if(doctorFilterVM is not null)
            //{
            //    Doctors = Doctors.Where(e => e.Specialization.Contains(doctorFilterVM.Specialization));
            //}
            var TotalNumberoffpage = Math.Ceiling(Doctors.Count() / 2.0);
            var  doctors = Doctors.Skip((page - 1) * 2).Take(2);
            ViewBag.TotalNumberoffpage=TotalNumberoffpage;
            ViewBag.currentpage = page;
            
            return View(doctors.ToList());
        }
        
        public ActionResult welcome()
        {
            int age = 39;
            string Name = "Kamal";
            List<string> skills = ["C++", "c#", "python"];
            var resualt = new PersonalInfo { Age = age, Name = Name, skills = skills };
            return View(resualt);
        }
        public IActionResult Details([FromRoute]int id )
        {
            var doctor = dbcontext.Doctors
                .FirstOrDefault(e => e.Id == id);

            if (doctor is not null)
            {
                var Doctro_related_sp = dbcontext.Doctors
                    .Where(e => e.Specialization == doctor.Specialization
                             && e.Id != doctor.Id).Skip(0)
                    .Take(4)
                    .ToList();

                var DoctorWithSPvm = new DoctorWithSpVM()
                {
                    Doctor = doctor,
                    Spdoctor = Doctro_related_sp
                };

                return View(DoctorWithSPvm);
            }

            return NotFound();
        }
       


         

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
