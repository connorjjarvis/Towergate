using Microsoft.AspNetCore.Mvc;
using Towergate.Models;
using Towergate.Database;

namespace Towergate.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerOp customerDb;

        public CustomerController(ICustomerOp _db)
        {
            customerDb = _db;
        }
        public IActionResult Index()
        {
            return View(customerDb.GetCustomers());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    customerDb.AddCustomer(customer);

                    return RedirectToAction("Index");
                }
                 else
                {
                    return View(customer);
                }
            }
            catch
            {
                return View(customer);
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = customerDb.GetCustomer(id);
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer customer)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var existingCustomer = customerDb.GetCustomer(id);
                    if (existingCustomer != null)
                    {
                        existingCustomer.Name = customer.Name;
                        existingCustomer.PostCode = customer.PostCode;
                        existingCustomer.Age = customer.Age;
                        existingCustomer.Height = customer.Height;

                        customerDb.UpdateCustomer(existingCustomer);

                        return RedirectToAction("Index");
                    }

                    return RedirectToAction("Index");
                } else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
