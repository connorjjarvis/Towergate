using System.ComponentModel.DataAnnotations;

namespace Towergate.Models
{
    public class CustomerViewModel
    {
        public IList<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}
