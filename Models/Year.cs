using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Year
    {
        [Key]
        public int Id { get; set; }

      
        public string Description { get; set; }

     
        public DateTime DateEntered { get; set; } = DateTime.Now;

        public string UserId { get; set; }
    }
}