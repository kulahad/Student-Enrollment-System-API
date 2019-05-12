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
    public class FacultiesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Faculties
        public IQueryable<Faculties> GetFaculties()
        {
            return db.Faculties;
        }

        // GET: api/Faculties/5
        [ResponseType(typeof(Faculties))]
        public IHttpActionResult GetFaculties(int id)
        {
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return NotFound();
            }

            return Ok(faculties);
        }

        // PUT: api/Faculties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFaculties(int id, Faculties faculties)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculties.Id)
            {
                return BadRequest();
            }

            db.Entry(faculties).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultiesExists(id))
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

        // POST: api/Faculties
        [ResponseType(typeof(Faculties))]
        public IHttpActionResult PostFaculties(Faculties faculties)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faculties.Add(faculties);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = faculties.Id }, faculties);
        }

        // DELETE: api/Faculties/5
        [ResponseType(typeof(Faculties))]
        public IHttpActionResult DeleteFaculties(int id)
        {
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return NotFound();
            }

            db.Faculties.Remove(faculties);
            db.SaveChanges();

            return Ok(faculties);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacultiesExists(int id)
        {
            return db.Faculties.Count(e => e.Id == id) > 0;
        }
    }
}