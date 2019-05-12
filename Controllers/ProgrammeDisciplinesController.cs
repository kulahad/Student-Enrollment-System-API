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
    public class ProgrammeDisciplinesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProgrammeDisciplines
        public IQueryable<ProgrammeDiscipline> GetProgrammeDisciplines()
        {
            return db.ProgrammeDisciplines;
        }

        // GET: api/ProgrammeDisciplines/5
        [ResponseType(typeof(ProgrammeDiscipline))]
        public IHttpActionResult GetProgrammeDiscipline(int id)
        {
            ProgrammeDiscipline programmeDiscipline = db.ProgrammeDisciplines.Find(id);
            if (programmeDiscipline == null)
            {
                return NotFound();
            }

            return Ok(programmeDiscipline);
        }

        // PUT: api/ProgrammeDisciplines/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgrammeDiscipline(int id, ProgrammeDiscipline programmeDiscipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programmeDiscipline.Id)
            {
                return BadRequest();
            }

            db.Entry(programmeDiscipline).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammeDisciplineExists(id))
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

        // POST: api/ProgrammeDisciplines
        [ResponseType(typeof(ProgrammeDiscipline))]
        public IHttpActionResult PostProgrammeDiscipline(ProgrammeDiscipline programmeDiscipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProgrammeDisciplines.Add(programmeDiscipline);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programmeDiscipline.Id }, programmeDiscipline);
        }

        // DELETE: api/ProgrammeDisciplines/5
        [ResponseType(typeof(ProgrammeDiscipline))]
        public IHttpActionResult DeleteProgrammeDiscipline(int id)
        {
            ProgrammeDiscipline programmeDiscipline = db.ProgrammeDisciplines.Find(id);
            if (programmeDiscipline == null)
            {
                return NotFound();
            }

            db.ProgrammeDisciplines.Remove(programmeDiscipline);
            db.SaveChanges();

            return Ok(programmeDiscipline);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgrammeDisciplineExists(int id)
        {
            return db.ProgrammeDisciplines.Count(e => e.Id == id) > 0;
        }
    }
}