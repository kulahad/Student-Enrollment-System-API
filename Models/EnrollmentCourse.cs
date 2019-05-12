using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class EnrollmentCourse
    {
        [Key]
        public int Id { get; set; }

        
        public int StudentEnrollmentId { get; set; }

        [ForeignKey("StudentEnrollmentId")]
        public StudentEnrollmentCourses StudentEnrollmentCourses { get; set; }


        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }

       public int EnrollmentStatusId { get; set; }

        [ForeignKey("EnrollmentStatusId")]
        public Status Status { get; set; }

        public DateTime DateEntered { get; set; } = DateTime.Now;


        public string UserId { get; set; }

        public int Year { get; set; } = DateTime.Now.Year;

    }
}