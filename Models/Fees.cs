using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Fees
    {

        [Key]
        public int Id { get; set; }

    
        public string Currency { get; set; }

      
        public decimal Amount { get; set; }

        public int YearId { get; set; }

        [ForeignKey("YearId")]

        public Year Year { get; set; }


       
        public DateTime DateEntered { get; set; } = DateTime.Now;

        public int CalendarYear { get; set; } = DateTime.Now.Year;

      
        public string UserId { get; set; }
    }
}