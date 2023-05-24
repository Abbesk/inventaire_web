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
    public class SocieteController : ApiController
    {
        private usererpEntities db = new usererpEntities();

        // GET: api/Societe
        [Authorize]
        public IQueryable<societe> Getsociete()
        {
            return db.societe;
        }

        [Authorize]
        [ResponseType(typeof(societe))]
        public IHttpActionResult Getsociete(string id)
        {
            societe societe = db.societe.Find(id);
            if (societe == null)
            {
                return NotFound();
            }

            return Ok(societe);
        }

        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsociete(string id, societe societe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != societe.code)
            {
                return BadRequest();
            }

            db.Entry(societe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!societeExists(id))
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

        [Authorize]
        [ResponseType(typeof(societe))]
        public IHttpActionResult Postsociete(societe societe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.societe.Add(societe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (societeExists(societe.code))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = societe.code }, societe);
        }

        [Authorize]
        [ResponseType(typeof(societe))]
        public IHttpActionResult Deletesociete(string id)
        {
            societe societe = db.societe.Find(id);
            if (societe == null)
            {
                return NotFound();
            }

            db.societe.Remove(societe);
            db.SaveChanges();

            return Ok(societe);
        }
        [Authorize]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        [Authorize]
        private bool societeExists(string id)
        {
            return db.societe.Count(e => e.code == id) > 0;
        }
    }
}