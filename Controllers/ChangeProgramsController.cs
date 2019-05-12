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
    public class ChangeProgramsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ChangePrograms
        public IQueryable<ChangeProgram> GetChangePrograms()
        {
            return db.ChangePrograms;
        }

        // GET: api/ChangePrograms/5
        [ResponseType(typeof(ChangeProgram))]
        public IHttpActionResult GetChangeProgram(int id)
        {
            ChangeProgram changeProgram = db.ChangePrograms.Find(id);
            if (changeProgram == null)
            {
                return NotFound();
            }

            return Ok(changeProgram);
        }

        // PUT: api/ChangePrograms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChangeProgram(int id, ChangeProgram changeProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != changeProgram.Id)
            {
                return BadRequest();
            }

            db.Entry(changeProgram).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChangeProgramExists(id))
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

        // POST: api/ChangePrograms
        [ResponseType(typeof(ChangeProgram))]
        public IHttpActionResult PostChangeProgram(ChangeProgram changeProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChangePrograms.Add(changeProgram);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = changeProgram.Id }, changeProgram);
        }

        // DELETE: api/ChangePrograms/5
        [ResponseType(typeof(ChangeProgram))]
        public IHttpActionResult DeleteChangeProgram(int id)
        {
            ChangeProgram changeProgram = db.ChangePrograms.Find(id);
            if (changeProgram == null)
            {
                return NotFound();
            }

            db.ChangePrograms.Remove(changeProgram);
            db.SaveChanges();

            return Ok(changeProgram);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChangeProgramExists(int id)
        {
            return db.ChangePrograms.Count(e => e.Id == id) > 0;
        }
    }
}