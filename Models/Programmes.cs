using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Programmes
    {
        [Key]
        public int Id { get; set; }

        
       
        public string Description { get; set; }


       
        public int ProgrammeDisciplineId { get; set; }

        [ForeignKey("ProgrammeDisciplineId")]
        public ProgrammeDiscipline ProgrammeDiscipline { get; set; }
    }
}