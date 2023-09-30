using MasterCRUD.Web.Data;
using System.Linq;

namespace MasterCRUD.Web.Models
{

    public class GetSingleCVModel
    {
        private readonly ApplicationDbContext _context;
        public GetSingleCVModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public ApplicantModel GetApplicant()
        {
            ApplicantModel applicant = new ApplicantModel();
            applicant = _context.Applicants.Find(new Guid("377dbbd5-452b-49fe-510b-08dbc1a956d4"));
            applicant.Educations = (IList<EducationModel>)_context.Educations.ToList();
            return applicant;
        }

    }

}
