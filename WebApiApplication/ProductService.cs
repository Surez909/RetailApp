using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            ProductsEntities entities = new ProductsEntities();
            return entities.Products.ToList();
        }
        public string AddOrder(Order _order)
        {
            string empty = string.Empty;
            string result = empty;
            ProductsEntities entities = new ProductsEntities();
            int availability = GetCurrentAvailability(_order.ProductId);
            if (availability - _order.Quantity >= 0)
            {
                Product updatedProduct = (from p in entities.Products
                    where p.ProductId == _order.ProductId
                    select p).FirstOrDefault();
                updatedProduct.Quantity = availability - _order.Quantity;
                entities.Orders.Add(_order);
                entities.SaveChanges();
                result = "Order placed";
            }
            else
            {
                result = "Unavailability of the product";
            }
            return result;
        }
        public string UpdateOrder(Order _order)
        {
            string result = string.Empty;
            ProductsEntities entities = new ProductsEntities();
            int availability = GetCurrentAvailability(_order.ProductId);
            Order updatedOrder = (from o in entities.Orders
                where o.ProductId == _order.ProductId
                select o).FirstOrDefault();
            if (availability - (_order.Quantity - updatedOrder.Quantity) >= 0)
            {
                Product updatedProduct = (from p in entities.Products
                    where p.ProductId == _order.ProductId
                    select p).FirstOrDefault();
                updatedProduct.Quantity = availability - (_order.Quantity - updatedOrder.Quantity);
                updatedOrder.Quantity = _order.Quantity;
                entities.SaveChanges();
                result = "Order Updated";
            }
            else
            {
                result = "Unavailability of the product";
            }
            return result;
        }
        public string DeleteOrder(Order _order)
        {
            ProductsEntities entities = new ProductsEntities();
            int availability = GetCurrentAvailability(_order.ProductId);
            Product updatedProduct = (from p in entities.Products
                where p.ProductId == _order.ProductId
                select p).FirstOrDefault();
            Order updatedOrder = (from o in entities.Orders
                where o.ProductId == _order.ProductId
                select o).FirstOrDefault();
            updatedProduct.Quantity = availability + updatedOrder.Quantity;
            entities.Orders.Remove(updatedOrder);
            entities.SaveChanges();
            return "Order Removed";
        }

        public int GetCurrentAvailability(int? cur_order)
        {
            ProductsEntities entities = new ProductsEntities();
            var cur_Availability = (from p in entities.Products where p.ProductId == cur_order select p).FirstOrDefault();
            return (int)cur_Availability.Quantity;
        }
    }
}