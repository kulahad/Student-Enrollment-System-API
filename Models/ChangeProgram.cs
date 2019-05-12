using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class ChangeProgram
    {
        [Key]
        public int Id { get; set; }
       
        public string StudentId { get; set; }
        
        public string LastName { get; set; }
        
        public string FirstNames { get; set; }
        
        public string MiddleName { get; set; }


        

        //[Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
       
        public string Campus { get; set; }
      
        public string Telephone { get; set; }
       
        public string ExamSite { get; set; }
       
        public string Email { get; set; }

        //Section B

      
        public string CurrentProgram { get; set; }
       
        public string CurrentMajor_Major1 { get; set; }
        
        public string CurrentMajor_Major2 { get; set; }
        
        public string CurrentMinor_Minor1 { get; set; }
     
        public string CurrentMinor_Minor2 { get; set; }

        //Section C
       
        public string NewProgram { get; set; }

        public string NewMajor_Major1 { get; set; }
        
        public string NewMajor_Major2 { get; set; }
        
        public string NewMinor_Minor1 { get; set; }
       
    
        public string NewMinor_Minor2 { get; set; }
        
        public bool ApprovalSponsor { get; set; }


        public bool StudentSignature { get; set; }

        public DateTime DateEntered { get; set; } = DateTime.Now;

        
        public string UserId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;

        public int StatusId { get; set; }

     
    }
}