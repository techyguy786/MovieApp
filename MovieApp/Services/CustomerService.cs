using MovieApp.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MovieApp.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers
                .Include(x => x.MembershipType)
                .ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return _context.Customers.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}