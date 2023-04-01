﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Inventaire_BackEnd.Models;

namespace Inventaire_BackEnd.Controllers
{
    public class FamilleController : ApiController
    {
        private somabeEntities db = new somabeEntities();

        // GET: api/Famille
        public IQueryable<famille> Getfamille()
        {
            return db.famille;
        }

        // GET: api/Famille/5
        [ResponseType(typeof(famille))]
        public IHttpActionResult Getfamille(string id)
        {
            famille famille = db.famille.Find(id);
            if (famille == null)
            {
                return NotFound();
            }

            return Ok(famille);
        }

        // PUT: api/Famille/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putfamille(string id, famille famille)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != famille.code)
            {
                return BadRequest();
            }

            db.Entry(famille).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!familleExists(id))
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

        // POST: api/Famille
        [ResponseType(typeof(famille))]
        public IHttpActionResult Postfamille(famille famille)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.famille.Add(famille);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (familleExists(famille.code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = famille.code }, famille);
        }

        // DELETE: api/Famille/5
        [ResponseType(typeof(famille))]
        public IHttpActionResult Deletefamille(string id)
        {
            famille famille = db.famille.Find(id);
            if (famille == null)
            {
                return NotFound();
            }

            db.famille.Remove(famille);
            db.SaveChanges();

            return Ok(famille);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool familleExists(string id)
        {
            return db.famille.Count(e => e.code == id) > 0;
        }
    }
}