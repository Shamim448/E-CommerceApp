using MasterCRUD.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MasterCRUD.Web.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        private readonly string _connectionString;
       
        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<ApplicantModel> Applicants { get; set; }
        public virtual DbSet<EducationModel> Educations { get; set; }
    }
}