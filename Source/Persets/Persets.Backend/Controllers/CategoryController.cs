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
using Persets.Backend.Data;
using System.Reflection;

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
            IHttpActionResult result = null;

            if (!ModelState.IsValid)
            {
                result = BadRequest(ModelState);
            }
            else if (id != categories.GUID)
            {
                result = BadRequest();
            }

            if (result != null)
            {
                LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, id, false);
                return result;
            }

            db.Entry(categories).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, id, true);
            }
            catch (DbUpdateConcurrencyException)
            {
                LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, id, false);

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
                LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, categories.GUID, false);
                return BadRequest(ModelState);
            }

            db.Categories.Add(categories);

            try
            {
                db.SaveChanges();
                LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, categories.GUID, true);
            }
            catch (DbUpdateException)
            {
                LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, categories.GUID, false);
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
                LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, id, false);
                return NotFound();
            }

            db.Categories.Remove(categories);
            db.SaveChanges();
            LogsDB.AddLog(MethodInfo.GetCurrentMethod().Name, LogsDB.eEntity.Category, id, true);

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