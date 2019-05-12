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
    public class ProgrammeTypesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProgrammeTypes
        public IQueryable<ProgrammeTypes> GetProgrammeTypes()
        {
            return db.ProgrammeTypes;
        }

        // GET: api/ProgrammeTypes/5
        [ResponseType(typeof(ProgrammeTypes))]
        public IHttpActionResult GetProgrammeTypes(int id)
        {
            ProgrammeTypes programmeTypes = db.ProgrammeTypes.Find(id);
            if (programmeTypes == null)
            {
                return NotFound();
            }

            return Ok(programmeTypes);
        }

        // PUT: api/ProgrammeTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProgrammeTypes(int id, ProgrammeTypes programmeTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != programmeTypes.Id)
            {
                return BadRequest();
            }

            db.Entry(programmeTypes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammeTypesExists(id))
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

        // POST: api/ProgrammeTypes
        [ResponseType(typeof(ProgrammeTypes))]
        public IHttpActionResult PostProgrammeTypes(ProgrammeTypes programmeTypes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProgrammeTypes.Add(programmeTypes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = programmeTypes.Id }, programmeTypes);
        }

        // DELETE: api/ProgrammeTypes/5
        [ResponseType(typeof(ProgrammeTypes))]
        public IHttpActionResult DeleteProgrammeTypes(int id)
        {
            ProgrammeTypes programmeTypes = db.ProgrammeTypes.Find(id);
            if (programmeTypes == null)
            {
                return NotFound();
            }

            db.ProgrammeTypes.Remove(programmeTypes);
            db.SaveChanges();

            return Ok(programmeTypes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProgrammeTypesExists(int id)
        {
            return db.ProgrammeTypes.Count(e => e.Id == id) > 0;
        }
    }
}