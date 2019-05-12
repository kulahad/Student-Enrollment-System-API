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
    public class ProgrammesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Programmes
        public IQueryable<Programmes> GetProgrammes()
        {
            return db.Programmes;
        }

        // GET: api/Programmes/5
        [ResponseType(typeof(Programmes))]
        public IHttpActionResult GetProgrammes(int id)
        {
            Programmes programmes = db.Programmes.Find(id);
            if (programmes == null)
            {
                return NotFound();
            }

            return Ok(programmes);
        }

        // PUT: api/Programmes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgrammes(int id, Programmes programmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programmes.Id)
            {
                return BadRequest();
            }

            db.Entry(programmes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammesExists(id))
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

        // POST: api/Programmes
        [ResponseType(typeof(Programmes))]
        public IHttpActionResult PostProgrammes(Programmes programmes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Programmes.Add(programmes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programmes.Id }, programmes);
        }

        // DELETE: api/Programmes/5
        [ResponseType(typeof(Programmes))]
        public IHttpActionResult DeleteProgrammes(int id)
        {
            Programmes programmes = db.Programmes.Find(id);
            if (programmes == null)
            {
                return NotFound();
            }

            db.Programmes.Remove(programmes);
            db.SaveChanges();

            return Ok(programmes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgrammesExists(int id)
        {
            return db.Programmes.Count(e => e.Id == id) > 0;
        }
    }
}