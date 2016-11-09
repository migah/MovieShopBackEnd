using MovieShopDll.Entities;
using MovieShopDll.Repository;

namespace MovieShopDll
{
    public class DllFacade
    {
        public IRepository<Genre> GetGenreRepository()
        {
            return new GenreRepository();
        }

        public IRepository<Movie> GetMovieRepository()
        {
            return new MovieRepository();
        }

        public IRepository<Customer> GetCustomerRepository()
        {
            return new CustomerRepository();
        }

        public IRepository<Order> GetOrderRepository()
        {
            return new OrderRepository();
        }

        public IRepository<Address> GetAddressRepository()
        {
            return new AddressRepository();
        }
    }
}
