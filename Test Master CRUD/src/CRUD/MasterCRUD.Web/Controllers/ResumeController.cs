using MasterCRUD.Web.Data;
using MasterCRUD.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
