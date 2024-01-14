using Towergate.Models;

namespace Towergate.Database
{
    public class CustomerOp : ICustomerOp
    {
        private static IList<Customer> _customers = new List<Customer>();

        static CustomerOp()
        {
            _customers = new List<Customer>
            {
                new Customer { Id = 0, Name = "John Doe", Age = 30, PostCode = "12345", Height = 1.5 }
            };
        }
        public IList<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(x => x.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            customer.Id = _customers.Max(c => c.Id) + 1;
            _customers.Add(customer);
        }

        public bool UpdateCustomer(Customer customer)
        {
            var cust = _customers.FirstOrDefault(x => x.Id == customer.Id);
            if (cust != null)
            {
                cust.Name = customer.Name;
                cust.Age = customer.Age;
                cust.Height = customer.Height;
                cust.PostCode = customer.PostCode;
                return true;
            }
            return false;
        }
    }
}
