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
    public class EnrollmentCoursesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/EnrollmentCourses
        public IQueryable<EnrollmentCourse> GetEnrollmentCourses()
        {
            return db.EnrollmentCourses;
        }

        // GET: api/EnrollmentCourses/5
        [ResponseType(typeof(EnrollmentCourse))]
        public IHttpActionResult GetEnrollmentCourse(int id)
        {
            EnrollmentCourse enrollmentCourse = db.EnrollmentCourses.Find(id);
            if (enrollmentCourse == null)
            {
                return NotFound();
            }

            return Ok(enrollmentCourse);
        }

        // PUT: api/EnrollmentCourses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEnrollmentCourse(int id, EnrollmentCourse enrollmentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != enrollmentCourse.Id)
            {
                return BadRequest();
            }

            db.Entry(enrollmentCourse).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnrollmentCourseExists(id))
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

        // POST: api/EnrollmentCourses
        [ResponseType(typeof(EnrollmentCourse))]
        public IHttpActionResult PostEnrollmentCourse(EnrollmentCourse enrollmentCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EnrollmentCourses.Add(enrollmentCourse);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = enrollmentCourse.Id }, enrollmentCourse);
        }

        // DELETE: api/EnrollmentCourses/5
        [ResponseType(typeof(EnrollmentCourse))]
        public IHttpActionResult DeleteEnrollmentCourse(int id)
        {
            EnrollmentCourse enrollmentCourse = db.EnrollmentCourses.Find(id);
            if (enrollmentCourse == null)
            {
                return NotFound();
            }

            db.EnrollmentCourses.Remove(enrollmentCourse);
            db.SaveChanges();

            return Ok(enrollmentCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EnrollmentCourseExists(int id)
        {
            return db.EnrollmentCourses.Count(e => e.Id == id) > 0;
        }
    }
}