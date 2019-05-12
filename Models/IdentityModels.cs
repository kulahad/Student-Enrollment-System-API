using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace API.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    { 
        public string FirstName { get; set; }
       public string LastName { get; set; }
    
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Campus> Campus { get; set; }
        public DbSet<Faculties> Faculties { get; set; }

        public DbSet<ProgrammeTypes> ProgrammeTypes { get; set; }
        public DbSet<ProgrammeDiscipline> ProgrammeDisciplines { get; set; }
        public DbSet<Programmes> Programmes { get; set; }

        public DbSet<Courses> Courses { get; set; }

        public DbSet<Prerequisite> Prerequisites { get; set; }

        public DbSet<CoursePrequist> CoursePrequists { get; set; }

        public DbSet<Semester> Semesters { get; set; }

        public DbSet<Year> Years { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Spin> Spins { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<StudentEnrollmentCourses> StudentEnrollmentCourses { get; set; }

        public DbSet<EnrollmentCourse> EnrollmentCourses { get; set; }

        public DbSet<Control> Controls { get; set; }

        public DbSet<ControlDates> ControlDates { get; set; }

        public DbSet<Fees> Fees { get; set; }



        public DbSet<FeesCharge> FeesCharges { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<API.Models.GradeReconsideration> GradeReconsiderations { get; set; }

        public System.Data.Entity.DbSet<API.Models.ChangeProgram> ChangePrograms { get; set; }

        public System.Data.Entity.DbSet<API.Models.ChangeProgramSAS> ChangeProgramSAS { get; set; }
    }
}