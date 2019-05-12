using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ChangeProgramSAS
    {
        [Key]
        public int Id { get; set; }

        public int ChangeId { get; set; }

        
        public string ChangeProgram { get; set; }

      
        public bool SpApprovalAttached { get; set; }
        
        public bool ProgramApproved { get; set; }

       
        public string SAS { get; set; }
        
        public string Recommendation { get; set; }




        public DateTime DateEntered { get; set; } = DateTime.Now;

       
        public string UserId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;

        public int StatusId { get; set; }

       
        public string Status { get; set; }
    }
}