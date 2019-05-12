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
    public class SpinsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Spins
        public IQueryable<Spin> GetSpins()
        {
            return db.Spins;
        }

        // GET: api/Spins/5
        [ResponseType(typeof(Spin))]
        public IHttpActionResult GetSpin(int id)
        {
            Spin spin = db.Spins.Find(id);
            if (spin == null)
            {
                return NotFound();
            }

            return Ok(spin);
        }

        // PUT: api/Spins/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSpin(int id, Spin spin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spin.Id)
            {
                return BadRequest();
            }

            db.Entry(spin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpinExists(id))
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

        // POST: api/Spins
        [ResponseType(typeof(Spin))]
        public IHttpActionResult PostSpin(Spin spin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Spins.Add(spin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = spin.Id }, spin);
        }

        // DELETE: api/Spins/5
        [ResponseType(typeof(Spin))]
        public IHttpActionResult DeleteSpin(int id)
        {
            Spin spin = db.Spins.Find(id);
            if (spin == null)
            {
                return NotFound();
            }

            db.Spins.Remove(spin);
            db.SaveChanges();

            return Ok(spin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SpinExists(int id)
        {
            return db.Spins.Count(e => e.Id == id) > 0;
        }
    }
}