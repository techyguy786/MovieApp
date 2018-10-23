using MovieApp.Models;
using MovieApp.Services;
using MovieApp.ViewModels;
using System.Web.Mvc;

namespace MovieApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerService _service;

        public CustomersController()
        {
            _service = new CustomerService();
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = _service.GetCustomers();
            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _service.GetMembershipTypes();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _service.GetCustomerById(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _service.GetMembershipTypes()
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _service.GetMembershipTypes()
                };
                return View("CustomerForm", viewModel);
            }

            var customerId = customer.Id;
            if (customerId == 0)
            {
                _service.AddCustomer(customer);
            }

            _service.UpdateCustomer(customer);

            return RedirectToAction("Index", "Customers");
        }
    }
}