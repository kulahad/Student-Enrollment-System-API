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
    public class ChangeProgramSASController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ChangeProgramSAS
        public IQueryable<ChangeProgramSAS> GetChangeProgramSAS()
        {
            return db.ChangeProgramSAS;
        }

        // GET: api/ChangeProgramSAS/5
        [ResponseType(typeof(ChangeProgramSAS))]
        public IHttpActionResult GetChangeProgramSAS(int id)
        {
            ChangeProgramSAS changeProgramSAS = db.ChangeProgramSAS.Find(id);
            if (changeProgramSAS == null)
            {
                return NotFound();
            }

            return Ok(changeProgramSAS);
        }

        // PUT: api/ChangeProgramSAS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChangeProgramSAS(int id, ChangeProgramSAS changeProgramSAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != changeProgramSAS.Id)
            {
                return BadRequest();
            }

            db.Entry(changeProgramSAS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeProgramSASExists(id))
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

        // POST: api/ChangeProgramSAS
        [ResponseType(typeof(ChangeProgramSAS))]
        public IHttpActionResult PostChangeProgramSAS(ChangeProgramSAS changeProgramSAS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChangeProgramSAS.Add(changeProgramSAS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = changeProgramSAS.Id }, changeProgramSAS);
        }

        // DELETE: api/ChangeProgramSAS/5
        [ResponseType(typeof(ChangeProgramSAS))]
        public IHttpActionResult DeleteChangeProgramSAS(int id)
        {
            ChangeProgramSAS changeProgramSAS = db.ChangeProgramSAS.Find(id);
            if (changeProgramSAS == null)
            {
                return NotFound();
            }

            db.ChangeProgramSAS.Remove(changeProgramSAS);
            db.SaveChanges();

            return Ok(changeProgramSAS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChangeProgramSASExists(int id)
        {
            return db.ChangeProgramSAS.Count(e => e.Id == id) > 0;
        }
    }
}