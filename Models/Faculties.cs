using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Faculties
    {

        [Key]
        public int Id { get; set; }

        
        public string Description { get; set; }

        
        public int CampusId { get; set; }

        [ForeignKey("CampusId")]

        public Campus Campus { get; set; }

       
        public DateTime DateEntered { get; set; } = DateTime.Now;

       
        public string UserId { get; set; }

    }
}