
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using MovieShopDll;

using MovieShopDll.Entities;

namespace MovieShopRestApi.Controllers
{
    public class CustomersController : ApiController
    {
        private IRepository<Customer> cr = new DllFacade().GetCustomerRepository();

        // GET: api/Customers
        public List<Customer> GetCustomers()
        {
            return cr.Read();
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult GetCustomer(int id)
        {
            Customer customer = cr.Read(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.CustomerId)
            {
                return BadRequest("IDs did not match");
            }

            cr.Update(customer);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Customers
        [ResponseType(typeof(Customer))]
        public IHttpActionResult PostCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cr.Create(customer);

            return CreatedAtRoute("DefaultApi", new { id = customer.CustomerId }, customer);
        }
        /// <summary>
        /// This is the delete function.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Customers/5
        [ResponseType(typeof(Customer))]
        public IHttpActionResult DeleteCustomer(int id)
        {
            Customer customer = cr.Read(id);
            if (customer == null)
            {
                return NotFound();
            }

            cr.Delete(id);

            return Ok(customer);
        }

    }
}