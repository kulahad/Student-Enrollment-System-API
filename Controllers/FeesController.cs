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
    public class FeesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Fees
        public IQueryable<Fees> GetFees()
        {
            return db.Fees;
        }

        // GET: api/Fees/5
        [ResponseType(typeof(Fees))]
        public IHttpActionResult GetFees(int id)
        {
            Fees fees = db.Fees.Find(id);
            if (fees == null)
            {
                return NotFound();
            }

            return Ok(fees);
        }

        // PUT: api/Fees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFees(int id, Fees fees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fees.Id)
            {
                return BadRequest();
            }

            db.Entry(fees).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeesExists(id))
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

        // POST: api/Fees
        [ResponseType(typeof(Fees))]
        public IHttpActionResult PostFees(Fees fees)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Fees.Add(fees);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fees.Id }, fees);
        }

        // DELETE: api/Fees/5
        [ResponseType(typeof(Fees))]
        public IHttpActionResult DeleteFees(int id)
        {
            Fees fees = db.Fees.Find(id);
            if (fees == null)
            {
                return NotFound();
            }

            db.Fees.Remove(fees);
            db.SaveChanges();

            return Ok(fees);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeesExists(int id)
        {
            return db.Fees.Count(e => e.Id == id) > 0;
        }
    }
}