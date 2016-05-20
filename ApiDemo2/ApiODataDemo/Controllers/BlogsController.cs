using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ApiDemo2.DataAccess;
using Domain;

namespace ApiODataDemo.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Extensions;
    using Domain;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Blog>("Blogs");
    builder.EntitySet<Post>("Posts"); 
    config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BlogsController : ODataController
    {
        private BlogContext db = new BlogContext();

        // GET: odata/Blogs
        [EnableQuery]
        public IQueryable<Blog> GetBlogs()
        {
            return db.Blogs;
        }

        // GET: odata/Blogs(5)
        [EnableQuery]
        public SingleResult<Blog> GetBlog([FromODataUri] int key)
        {
            return SingleResult.Create(db.Blogs.Where(blog => blog.Id == key));
        }

        // PUT: odata/Blogs(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Blog> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Blog blog = db.Blogs.Find(key);
            if (blog == null)
            {
                return NotFound();
            }

            patch.Put(blog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(blog);
        }

        // POST: odata/Blogs
        public IHttpActionResult Post(Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Blogs.Add(blog);
            db.SaveChanges();

            return Created(blog);
        }

        // PATCH: odata/Blogs(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Blog> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Blog blog = db.Blogs.Find(key);
            if (blog == null)
            {
                return NotFound();
            }

            patch.Patch(blog);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(blog);
        }

        // DELETE: odata/Blogs(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Blog blog = db.Blogs.Find(key);
            if (blog == null)
            {
                return NotFound();
            }

            db.Blogs.Remove(blog);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Blogs(5)/Posts
        [EnableQuery]
        public IQueryable<Post> GetPosts([FromODataUri] int key)
        {
            return db.Blogs.Where(m => m.Id == key).SelectMany(m => m.Posts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BlogExists(int key)
        {
            return db.Blogs.Count(e => e.Id == key) > 0;
        }
    }
}
