using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class StudentEnrollmentCoursesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StudentEnrollmentCourses
        public IQueryable<StudentEnrollmentCourses> GetStudentEnrollmentCourses()
        {
            return db.StudentEnrollmentCourses;
        }

        // GET: api/StudentEnrollmentCourses/5
        [ResponseType(typeof(StudentEnrollmentCourses))]
        public IHttpActionResult GetStudentEnrollmentCourses(int id)
        {
            StudentEnrollmentCourses studentEnrollmentCourses = db.StudentEnrollmentCourses.Find(id);
            if (studentEnrollmentCourses == null)
            {
                return NotFound();
            }

            return Ok(studentEnrollmentCourses);
        }

        // PUT: api/StudentEnrollmentCourses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudentEnrollmentCourses(int id, StudentEnrollmentCourses studentEnrollmentCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentEnrollmentCourses.Id)
            {
                return BadRequest();
            }

            db.Entry(studentEnrollmentCourses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentEnrollmentCoursesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StudentEnrollmentCourses
        [ResponseType(typeof(StudentEnrollmentCourses))]
        public IHttpActionResult PostStudentEnrollmentCourses(StudentEnrollmentCourses studentEnrollmentCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StudentEnrollmentCourses.Add(studentEnrollmentCourses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentEnrollmentCourses.Id }, studentEnrollmentCourses);
        }

        // DELETE: api/StudentEnrollmentCourses/5
        [ResponseType(typeof(StudentEnrollmentCourses))]
        public IHttpActionResult DeleteStudentEnrollmentCourses(int id)
        {
            StudentEnrollmentCourses studentEnrollmentCourses = db.StudentEnrollmentCourses.Find(id);
            if (studentEnrollmentCourses == null)
            {
                return NotFound();
            }

            db.StudentEnrollmentCourses.Remove(studentEnrollmentCourses);
            db.SaveChanges();

            return Ok(studentEnrollmentCourses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentEnrollmentCoursesExists(int id)
        {
            return db.StudentEnrollmentCourses.Count(e => e.Id == id) > 0;
        }
    }
}