 using MasterCRUD.Web.Data;
using MasterCRUD.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MasterCRUD.Web.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ResumeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<ApplicantModel> applicants;
            applicants = _context.Applicants.ToList();
            return View(applicants);
        }

        public IActionResult Create() 
        { 
            ApplicantModel applicant = new ApplicantModel();
            applicant.Educations.Add(new EducationModel() { Id = new Guid("60683883-8780-4797-889B-AF912DAFB18B") });
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Create(ApplicantModel model)
        {
            foreach (EducationModel edu in model.Educations)
            {
                if(edu.Degree == null || edu.Degree.Length == 0)
                    model.Educations.Remove(edu);
            }
            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");    
        }

        public IActionResult ViewCV(Guid id)
        {           
            var applicant = _context.Applicants
                            .Include(a => a.Educations).Where(e => e.Id == id).FirstOrDefault();
            var tem = 2;
            if(tem == 1)
            {
                return View("Template", applicant);
            }
            return View(applicant);
        }
    }
}
