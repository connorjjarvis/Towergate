using Towergate.Models;

namespace Towergate.Database
{
    public class CustomerOp : ICustomerOp
    {
        static IList<Customer> _customers = new List<Customer>();

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
            _customers.Add(customer);
        }
    }
}
