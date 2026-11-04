using Clinic.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorsControlls : Controller
    {
        private ApplicationDbcontext dbcontext = new();
        public IActionResult Index()
        {
            var Doctor = dbcontext.Doctors;
            return View(Doctor.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            dbcontext.Add(doctor);
            dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
        [HttpGet]
        public IActionResult Edit([FromRoute] int id)
        {
            var doctor = dbcontext.Doctors.Find(id);
            if (doctor is not null)
            {

                return View(doctor);
            }
            return RedirectToAction("NotFoundPage", "Home");
        }
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            dbcontext.Update(doctor);
            dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));


        }
        public IActionResult Delete([FromRoute] int id)
        {
            var Doctor = dbcontext.Doctors.Find(id);
            if (Doctor is not null)
            {
                dbcontext.Remove(Doctor);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("NotFoundPage", "Home");

        }


    }

}

