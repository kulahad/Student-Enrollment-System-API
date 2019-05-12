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
    public class ControlDatesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ControlDates
        public IQueryable<ControlDates> GetControlDates()
        {
            return db.ControlDates;
        }

        // GET: api/ControlDates/5
        [ResponseType(typeof(ControlDates))]
        public IHttpActionResult GetControlDates(int id)
        {
            ControlDates controlDates = db.ControlDates.Find(id);
            if (controlDates == null)
            {
                return NotFound();
            }

            return Ok(controlDates);
        }

        // PUT: api/ControlDates/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControlDates(int id, ControlDates controlDates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controlDates.ControlId)
            {
                return BadRequest();
            }

            db.Entry(controlDates).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlDatesExists(id))
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

        // POST: api/ControlDates
        [ResponseType(typeof(ControlDates))]
        public IHttpActionResult PostControlDates(ControlDates controlDates)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ControlDates.Add(controlDates);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ControlDatesExists(controlDates.ControlId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = controlDates.ControlId }, controlDates);
        }

        // DELETE: api/ControlDates/5
        [ResponseType(typeof(ControlDates))]
        public IHttpActionResult DeleteControlDates(int id)
        {
            ControlDates controlDates = db.ControlDates.Find(id);
            if (controlDates == null)
            {
                return NotFound();
            }

            db.ControlDates.Remove(controlDates);
            db.SaveChanges();

            return Ok(controlDates);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ControlDatesExists(int id)
        {
            return db.ControlDates.Count(e => e.ControlId == id) > 0;
        }
    }
}