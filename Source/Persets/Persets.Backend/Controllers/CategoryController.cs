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
using Persets.Backend.Models;

namespace Persets.Backend.Controllers
{
    public class CategoryController : ApiController
    {
        private PersetsDBEntities db = new PersetsDBEntities();

        // GET: api/Category
        public IQueryable<Categories> GetCategories()
        {
            return db.Categories;
        }

        // GET: api/Category/5
        [ResponseType(typeof(Categories))]
        public IHttpActionResult GetCategories(string id)
        {
            Categories categories = db.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            return Ok(categories);
        }

        // PUT: api/Category/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategories(string id, Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categories.GUID)
            {
                return BadRequest();
            }

            db.Entry(categories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriesExists(id))
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

        // POST: api/Category
        [ResponseType(typeof(Categories))]
        public IHttpActionResult PostCategories(Categories categories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Categories.Add(categories);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CategoriesExists(categories.GUID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = categories.GUID }, categories);
        }

        // DELETE: api/Category/5
        [ResponseType(typeof(Categories))]
        public IHttpActionResult DeleteCategories(string id)
        {
            Categories categories = db.Categories.Find(id);
            if (categories == null)
            {
                return NotFound();
            }

            db.Categories.Remove(categories);
            db.SaveChanges();

            return Ok(categories);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoriesExists(string id)
        {
            return db.Categories.Count(e => e.GUID == id) > 0;
        }
    }
}