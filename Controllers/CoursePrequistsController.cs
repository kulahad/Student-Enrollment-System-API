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
    public class CoursePrequistsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/CoursePrequists
        public IQueryable<CoursePrequist> GetCoursePrequists()
        {
            return db.CoursePrequists;
        }

        // GET: api/CoursePrequists/5
        [ResponseType(typeof(CoursePrequist))]
        public IHttpActionResult GetCoursePrequist(int id)
        {
            CoursePrequist coursePrequist = db.CoursePrequists.Find(id);
            if (coursePrequist == null)
            {
                return NotFound();
            }

            return Ok(coursePrequist);
        }

        // PUT: api/CoursePrequists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCoursePrequist(int id, CoursePrequist coursePrequist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != coursePrequist.Id)
            {
                return BadRequest();
            }

            db.Entry(coursePrequist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursePrequistExists(id))
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

        // POST: api/CoursePrequists
        [ResponseType(typeof(CoursePrequist))]
        public IHttpActionResult PostCoursePrequist(CoursePrequist coursePrequist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CoursePrequists.Add(coursePrequist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = coursePrequist.Id }, coursePrequist);
        }

        // DELETE: api/CoursePrequists/5
        [ResponseType(typeof(CoursePrequist))]
        public IHttpActionResult DeleteCoursePrequist(int id)
        {
            CoursePrequist coursePrequist = db.CoursePrequists.Find(id);
            if (coursePrequist == null)
            {
                return NotFound();
            }

            db.CoursePrequists.Remove(coursePrequist);
            db.SaveChanges();

            return Ok(coursePrequist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CoursePrequistExists(int id)
        {
            return db.CoursePrequists.Count(e => e.Id == id) > 0;
        }
    }
}