using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class GradeReconsideration
    {
        [Key]
        public int Id { get; set; }
        public string StudentId { get; set; }

        public string FirstNames { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }


        //[Display(Name = "Date of Birth"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool PrivateStudent { get; set; }
        public bool SponsoredStudent { get; set; }

        public string SponsorName { get; set; }

        public string Bank { get; set; }

        public string Branch { get; set; }
        public string AccountNo { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public string LecturerName { get; set; }

        public string ReceiptNo { get; set; }





        //system information
        public DateTime DateEntered { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string UserId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;

        public int StatusId { get; set; }
       



    }
}