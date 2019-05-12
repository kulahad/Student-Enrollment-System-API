using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }

       
        public string Code { get; set; }

       
        public string CourseDescription { get; set; }
    }
}