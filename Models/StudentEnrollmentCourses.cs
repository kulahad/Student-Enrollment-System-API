using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class StudentEnrollmentCourses
    {
        [Key]
        public int Id { get; set; }
   
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Students { get; set; }
        
        public int ProgrammeId { get; set; }

        [ForeignKey("ProgrammeId")]
        public Programmes Programmes { get; set; }
       
        public int YearId { get; set; }

        [ForeignKey("YearId")]
        public Year Years { get; set; }

        public int SemesterId { get; set; }

        [ForeignKey("SemesterId")]
        public Semester Semester { get; set; }

        
        public int EnrollmentStatusId { get; set; }

        [ForeignKey("EnrollmentStatusId")]
        public Status Status { get; set; }

       
        public DateTime DateEntered { get; set; } = DateTime.Now;


        public string UserId { get; set; }

        public int Year { get; set; } = DateTime.Now.Year;


    }
}