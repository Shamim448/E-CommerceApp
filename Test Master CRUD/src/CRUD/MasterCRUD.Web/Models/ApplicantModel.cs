
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterCRUD.Web.Models
{
    public class ApplicantModel 
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        [DisplayName("First Name")]
        public string? FName { get; set; }

        [StringLength(150)]
        [DisplayName("Middle Name (Optional)")]
        public string? MName { get; set; }

        [Required]
        [StringLength(150)]
        [DisplayName("Last Name")]
        public string? LName { get; set; }

        public string? Designation { get; set; }
        [Required]
        [StringLength(250)]
        public string? Address { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(15)]
        public string? PhoneNo { get; set; }
        [Required]
        [StringLength(300)]
        public string? Summary { get; set; }

        public string PhotoUrl { get; set; }
        [Required(ErrorMessage ="Please choose the profile  photo")]
        [Display(Name = "Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }

        public IList<EducationModel>? Educations { get; set; } = new List<EducationModel>();
    }
}
