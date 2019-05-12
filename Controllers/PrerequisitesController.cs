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
    public class PrerequisitesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Prerequisites
        public IQueryable<Prerequisite> GetPrerequisites()
        {
            return db.Prerequisites;
        }

        // GET: api/Prerequisites/5
        [ResponseType(typeof(Prerequisite))]
        public IHttpActionResult GetPrerequisite(int id)
        {
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return NotFound();
            }

            return Ok(prerequisite);
        }

        // PUT: api/Prerequisites/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPrerequisite(int id, Prerequisite prerequisite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != prerequisite.Id)
            {
                return BadRequest();
            }

            db.Entry(prerequisite).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrerequisiteExists(id))
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

        // POST: api/Prerequisites
        [ResponseType(typeof(Prerequisite))]
        public IHttpActionResult PostPrerequisite(Prerequisite prerequisite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Prerequisites.Add(prerequisite);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prerequisite.Id }, prerequisite);
        }

        // DELETE: api/Prerequisites/5
        [ResponseType(typeof(Prerequisite))]
        public IHttpActionResult DeletePrerequisite(int id)
        {
            Prerequisite prerequisite = db.Prerequisites.Find(id);
            if (prerequisite == null)
            {
                return NotFound();
            }

            db.Prerequisites.Remove(prerequisite);
            db.SaveChanges();

            return Ok(prerequisite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrerequisiteExists(int id)
        {
            return db.Prerequisites.Count(e => e.Id == id) > 0;
        }
    }
}