using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class Student
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SPIN { get; set; }
        
      
        public string FirstNames { get; set; }

      
        public string MiddleName { get; set; }

     
        public string LastName { get; set; }

        
        public int GenderId { get; set; }

        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        public string Citizenship { get; set; }

      
        public int ProgramId { get; set; }
        [ForeignKey("ProgramId")]

        public ProgrammeDiscipline ProgrammeDisciplines { get; set; }


      
        public int ProgrammeTypesId { get; set; }

        [ForeignKey("ProgrammeTypesId")]
        public ProgrammeTypes ProgrammeTypes { get; set; }


     
        public int CampusId { get; set; }

        [ForeignKey("CampusId")]
        public Campus Campus { get; set; }

        public string ExamSite { get; set; }

     
        public int ProgrammesId { get; set; }

        [ForeignKey("ProgrammesId")]
        public Programmes Programmes { get; set; }
        
        public int ProgrammesId1 { get; set; }

        [ForeignKey("ProgrammesId1")]
        public Programmes Programmes1 { get; set; }



      
        public int ProgrammesId2 { get; set; }

        [ForeignKey("ProgrammesId2")]
        public Programmes Programmes2 { get; set; }


       
        public int ProgrammesId3 { get; set; }


        [ForeignKey("ProgrammesId3")]
        public Programmes Programmes3 { get; set; }

        
        public int ProgrammesId4 { get; set; }


        [ForeignKey("ProgrammesId4")]
        public Programmes Programmes4 { get; set; }


        public DateTime DateEntered { get; set; } = DateTime.Now;

        
        public string UserId { get; set; }
    }
}