using Microsoft.AspNetCore.Mvc;
using Towergate.Models;

namespace Towergate.Controllers
{
    public class CustomerController : Controller
    {
        private List<Customer> customers;

        public CustomerController()
        {
            customers = new List<Customer>()
            {
                new Customer()
                { Id = 0, Name = "Connor Jarvis", Age = 29, PostCode = "TA116EG", Height=1.8 },
            };
        }
        public IActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var customer = customers.FirstOrDefault(x => x.Id == id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {

            try
            {
                var customer = new Customer();
                customer.Id = id;
                customer.Name = collection["Name"].ToString();
                customer.PostCode = collection["PostCode"].ToString();
                customer.Age = int.Parse(collection["Age"]);
                customer.Height = double.Parse(collection["Height"]);

                var originalCustomer = customers.FirstOrDefault(x => x.Id == id);
                originalCustomer = customer;

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
