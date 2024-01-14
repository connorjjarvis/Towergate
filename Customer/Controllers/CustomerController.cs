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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var customer = new Customer();
                customer.Name = collection["Name"].ToString();
                customer.PostCode = collection["PostCode"].ToString();
                customer.Age = int.Parse(collection["Age"]);
                customer.Height = double.Parse(collection["Height"]);

                customerDb.AddCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = customerDb.GetCustomer(id);
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
                
                customerDb.UpdateCustomer(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
