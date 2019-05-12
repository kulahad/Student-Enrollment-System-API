using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class CoursePrequist
    {
        [Key]
        public int Id { get; set; }

       
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]

        public Courses Courses { get; set; }

        public int PrerequistId { get; set; }

        [ForeignKey("PrerequistId")]

        public Prerequisite Prerequisites { get; set; }

       
        public int ProgramId { get; set; }

        [ForeignKey("ProgramId")]

        public Programmes Programmes { get; set; }



       
        public int SemesterId { get; set; }


        [ForeignKey("SemesterId")]

        public Semester Semester { get; set; }

       
        public int YearId { get; set; }

        [ForeignKey("YearId")]

        public Year Year { get; set; }


        public DateTime DateEntered { get; set; } = DateTime.Now;

        
        public string UserId { get; set; }
    }
}