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
    public class MoviesController : ApiController
    {
        private IRepository<Movie> mr = new DllFacade().GetMovieRepository();

        // GET: api/Movies
        public List<Movie> GetMovies()
        {
            return mr.Read();
        }

        // GET: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            Movie movie = mr.Read(id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            mr.Update(movie);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [ResponseType(typeof(Movie))]
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            mr.Create(movie);

            return CreatedAtRoute("DefaultApi", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/Movies/5
        [ResponseType(typeof(Movie))]
        public IHttpActionResult DeleteMovie(int id)
        {
            Movie movie = mr.Read(id);
            if (movie == null)
            {
                return NotFound();
            }

            mr.Delete(id);

            return Ok(movie);
        }

    }
}