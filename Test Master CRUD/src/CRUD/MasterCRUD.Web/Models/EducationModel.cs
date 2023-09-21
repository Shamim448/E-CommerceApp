
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MasterCRUD.Web.Models
{
    public class EducationModel 
    {
        [Key]
        public Guid Id { get; set; }
        //one to one       
        [ForeignKey("Applicant")]
        public Guid ApplicantId { get; set; }
        public ApplicantModel Applicant { get; set; }


        [Required]
        [StringLength(50)]
        public string? Institution { get; set; }
        [Required]
        [StringLength(50)]
        public string? Degree { get; set; }
        [Required]
        [StringLength(50)]
        public string? City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }

        

        public EducationModel()
        {
            
        }

    }
}
