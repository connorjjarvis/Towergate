using Towergate.Models;

namespace Towergate.Database
{
    public interface ICustomerOp
    {
        IList<Customer> GetCustomers();
        void AddCustomer(Customer customer);
        Customer GetCustomer(int id);

        bool UpdateCustomer(Customer customer);
    }
}
