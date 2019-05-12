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
    public class FeesChargesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/FeesCharges
        public IQueryable<FeesCharge> GetFeesCharges()
        {
            return db.FeesCharges;
        }

        // GET: api/FeesCharges/5
        [ResponseType(typeof(FeesCharge))]
        public IHttpActionResult GetFeesCharge(int id)
        {
            FeesCharge feesCharge = db.FeesCharges.Find(id);
            if (feesCharge == null)
            {
                return NotFound();
            }

            return Ok(feesCharge);
        }

        // PUT: api/FeesCharges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFeesCharge(int id, FeesCharge feesCharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != feesCharge.Id)
            {
                return BadRequest();
            }

            db.Entry(feesCharge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeesChargeExists(id))
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

        // POST: api/FeesCharges
        [ResponseType(typeof(FeesCharge))]
        public IHttpActionResult PostFeesCharge(FeesCharge feesCharge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FeesCharges.Add(feesCharge);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = feesCharge.Id }, feesCharge);
        }

        // DELETE: api/FeesCharges/5
        [ResponseType(typeof(FeesCharge))]
        public IHttpActionResult DeleteFeesCharge(int id)
        {
            FeesCharge feesCharge = db.FeesCharges.Find(id);
            if (feesCharge == null)
            {
                return NotFound();
            }

            db.FeesCharges.Remove(feesCharge);
            db.SaveChanges();

            return Ok(feesCharge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FeesChargeExists(int id)
        {
            return db.FeesCharges.Count(e => e.Id == id) > 0;
        }
    }
}