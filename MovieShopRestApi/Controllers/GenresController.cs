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
using MovieShopDll;
using MovieShopDll.Contexts;
using MovieShopDll.Entities;

namespace MovieShopRestApi.Controllers
{
    public class GenresController : ApiController
    {
        private IRepository<Genre> gr = new DllFacade().GetGenreRepository();

        // GET: api/Genres
        public List<Genre> GetGenres()
        {
            return gr.Read();
        }

        // GET: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult GetGenre(int id)
        {
            Genre genre = gr.Read(id);
            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }

        // PUT: api/Genres/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGenre(int id, Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != genre.GenreId)
            {
                return BadRequest();
            }

            gr.Update(genre);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Genres
        [ResponseType(typeof(Genre))]
        public IHttpActionResult PostGenre(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            gr.Create(genre);

            return CreatedAtRoute("DefaultApi", new { id = genre.GenreId }, genre);
        }

        // DELETE: api/Genres/5
        [ResponseType(typeof(Genre))]
        public IHttpActionResult DeleteGenre(int id)
        {
            Genre genre = gr.Read(id);
            if (genre == null)
            {
                return NotFound();
            }

            gr.Delete(id);

            return Ok(genre);
        }

    }
}