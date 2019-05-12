using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ControlDates
    {

       
        public int Year { get; set; }

        [Key]
        public int ControlId { get; set; }

        [ForeignKey("ControlId")]
        public Control Control { get; set; }

        
        public DateTime StartDate { get; set; }

       
        public DateTime EndDate { get; set; }


        public DateTime DateEntered { get; set; } = DateTime.Now;


        public string UserId { get; set; }
    }
}