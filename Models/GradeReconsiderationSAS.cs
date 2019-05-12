using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class GradeReconsiderationSAS
    {


        public int Id { get; set; }


        public int GradeRecId { get; set; }

        [ForeignKey("GradeRecId")]
        public GradeReconsideration GradeReconsideration { get; set; }

        //Part B

        public string To { get; set; }
        public string ManagerSAS { get; set; }
        //[ DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; } = DateTime.Now;

        //Part C

        public string From { get; set; }
        public string Recommendation { get; set; }

        public string CACurrentMarks { get; set; }
        public string CARevisedMarks { get; set; }
        public string EMCurrentMarks { get; set; }
        public string EMRevisedMarks { get; set; }
        public string TotalCurrent { get; set; }
        public string TotalRevised { get; set; }

        public string GradeChangeReason { get; set; }

        public bool Lecturer { get; set; }
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LecturerDate { get; set; } = DateTime.Now;

        public bool HeadofSchool { get; set; }
        //[ DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HeadofSchoolDate { get; set; } = DateTime.Now;

        public bool Dean { get; set; }
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DeanDate { get; set; } = DateTime.Now;



        //system information
        public DateTime DateEntered { get; set; } = DateTime.Now;

        [StringLength(255)]
        public string UserId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;

        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Status Status { get; set; }
    }
}