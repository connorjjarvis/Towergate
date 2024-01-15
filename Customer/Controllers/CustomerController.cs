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
        public ActionResult Index()
        {
            var viewModel = new CustomerViewModel
            {
                Customers = customerDb.GetCustomers(),
                Customer = new Customer()
            };
            return View(viewModel);
        }

        public ActionResult Create()
        {
            return PartialView("_CreateModal");
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
                    return PartialView("_CreateModal", customer);
                }
            }
            catch
            {
                return PartialView("_CreateModal",customer);
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = customerDb.GetCustomer(id);
            return PartialView("_EditModal", customer);
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

                    return PartialView("_EditModal", customer);
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
