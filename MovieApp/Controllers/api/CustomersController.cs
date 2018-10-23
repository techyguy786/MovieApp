using AutoMapper;
using MovieApp.DTOs;
using MovieApp.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace MovieApp.Controllers.api
{
    public class CustomersController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers  
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>));
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /api/customers  
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),
                customerDTO);
        }

        // PUT /api/customers/1  
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }


            var custmr = _context.Customers.SingleOrDefault(x => x.Id == id);

            // Might be user sends invalid id.  
            if (custmr == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDTO, custmr);
            //Mapper.Map<CustomerDTO, Customer>(customerDTO, custmr);
            //custmr.Birthdate = customer.Birthdate;
            //custmr.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //custmr.Name = customer.Name;
            //custmr.MembershipTypeId = customer.MembershipTypeId;

            _context.SaveChanges();
            return Ok(custmr);
        }

        // Delete /api/customers/1  
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var custmr = _context.Customers.SingleOrDefault(x => x.Id == id);

            // Might be user sends invalid id.  
            if (custmr == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(custmr);
            // Now the object is marked as removed in memory  


            // Now it is done  
            _context.SaveChanges();
            return Ok(custmr);
        }
    }
}
