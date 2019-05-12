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
    public class GradeReconsiderationsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/GradeReconsiderations
        public IQueryable<GradeReconsideration> GetGradeReconsiderations()
        {
            return db.GradeReconsiderations;
        }

        // GET: api/GradeReconsiderations/5
        [ResponseType(typeof(GradeReconsideration))]
        public IHttpActionResult GetGradeReconsideration(int id)
        {
            GradeReconsideration gradeReconsideration = db.GradeReconsiderations.Find(id);
            if (gradeReconsideration == null)
            {
                return NotFound();
            }

            return Ok(gradeReconsideration);
        }

        // PUT: api/GradeReconsiderations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGradeReconsideration(int id, GradeReconsideration gradeReconsideration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gradeReconsideration.Id)
            {
                return BadRequest();
            }

            db.Entry(gradeReconsideration).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeReconsiderationExists(id))
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

        // POST: api/GradeReconsiderations
        [ResponseType(typeof(GradeReconsideration))]
        public IHttpActionResult PostGradeReconsideration(GradeReconsideration gradeReconsideration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GradeReconsiderations.Add(gradeReconsideration);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gradeReconsideration.Id }, gradeReconsideration);
        }

        // DELETE: api/GradeReconsiderations/5
        [ResponseType(typeof(GradeReconsideration))]
        public IHttpActionResult DeleteGradeReconsideration(int id)
        {
            GradeReconsideration gradeReconsideration = db.GradeReconsiderations.Find(id);
            if (gradeReconsideration == null)
            {
                return NotFound();
            }

            db.GradeReconsiderations.Remove(gradeReconsideration);
            db.SaveChanges();

            return Ok(gradeReconsideration);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GradeReconsiderationExists(int id)
        {
            return db.GradeReconsiderations.Count(e => e.Id == id) > 0;
        }
    }
}