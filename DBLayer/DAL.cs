using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBLayer
{
    public static class DAL
    {
        static ProductsEntities DbContext;
        static DAL()
        {
            DbContext = new ProductsEntities();
        }
        public static List<Product> GetAllProducts()
        {
            var res = DbContext.Products.ToList();
            return res;
        }
    }
}