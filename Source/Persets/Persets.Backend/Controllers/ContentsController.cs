using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Persets.Backend.Models;
using Persets.Backend.Models.ViewModels;

namespace Persets.Backend.Controllers
{
    public class ContentsController : ApiController
    {
        private PersetsDBEntities db = new PersetsDBEntities();

        // GET: api/Contents
        public IQueryable<Content> GetContent()
        {
            return db.Content;
        }

        // GET: api/Contents/5
        [ResponseType(typeof(Content))]
        public async Task<IHttpActionResult> GetContent(string id)
        {
            Content content = await db.Content.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }

        [AllowAnonymous]
        // PUT: api/Contents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContent(string id, Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != content.GUID)
            {
                return BadRequest();
            }

            db.Entry(content).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentExists(id))
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

        // POST: api/Contents
        [ResponseType(typeof(Content))]
        public async Task<IHttpActionResult> PostContent(Content content)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Content.Add(content);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ContentExists(content.GUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = content.GUID }, content);
        }

        // DELETE: api/Contents/5
        [ResponseType(typeof(Content))]
        public async Task<IHttpActionResult> DeleteContent(string id)
        {
            Content content = await db.Content.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }

            db.Content.Remove(content);
            await db.SaveChangesAsync();

            return Ok(content);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContentExists(string id)
        {
            return db.Content.Count(e => e.GUID == id) > 0;
        }
    }
}