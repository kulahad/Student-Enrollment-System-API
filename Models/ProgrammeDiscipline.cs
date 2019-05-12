using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ProgrammeDiscipline
    {
        [Key]
        public int Id { get; set; }

      
        public string Description { get; set; }

        
        public int ProgrammeTypesId { get; set; }

        [ForeignKey("ProgrammeTypesId")]
        public ProgrammeTypes ProgrammeTypes { get; set; }

       
        public int FacultyId { get; set; }

        [ForeignKey("FacultyId")]
        public Faculties Faculties { get; set; }

       
        public DateTime DateEntered { get; set; } = DateTime.Now;

        
        public string UserId { get; set; }
    }
}