using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class FeesCharge
    {

        [Key]
        public int Id { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]

        public Student Student { get; set; }

        
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]

        public Courses Courses { get; set; }

       
        public int YearId { get; set; }

        [ForeignKey("YearId")]

        public Year Year { get; set; }


       
        public int FeesId { get; set; }

        [ForeignKey("FeesId")]

        public Fees Fees { get; set; }

        
        public DateTime DateEntered { get; set; } = DateTime.Now;

      
        public int CalendarYear { get; set; } = DateTime.Now.Year;

       
        public string UserId { get; set; }

    }
}