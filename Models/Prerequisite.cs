using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Prerequisite
    {
        [Key]
        public int Id { get; set; }

        
        public string Description { get; set; }
    }
}