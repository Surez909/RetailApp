using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;

namespace WebApiApplication
{
    public interface IProductService
    {
        List<Product> GetProducts();
        string AddOrder(Order order);
        string UpdateOrder(Order order);
        string DeleteOrder(Order order);
    }
}
