using AutoMoq;
using DBLayer;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiApplication;

namespace WebApiApplicationUnitTest
{
    [TestFixture]
    public class ProductServiceUnitTest
    {
        private ProductService _service;
        private AutoMoqer _autoMoqer;
        private Mock<IProductService> _productService;

        [SetUp]
        public void SetUp()
        {
            _autoMoqer = new AutoMoqer();
            _service = _autoMoqer.Create<ProductService>();
            _productService = _autoMoqer.GetMock<IProductService>();
        }

        [Test]
        public void ValidateAddOrder_GivenValidInput_ReturnsData()
        {
            Order _order = new Order();
            _order.ProductId = 2;
            _order.Quantity = 10;

            _productService
               .Setup(v => v.AddOrder(_order))
               .Returns("Order placed");

            var result = _service.AddOrder(_order);
            Assert.That(result, Is.EqualTo("Order placed"));
            _productService.VerifyAll();
        }

        [Test]
        public void ValidateUpdateOrder_GivenValidInput_ReturnsData()
        {
            Order _order = new Order();
            _order.ProductId = 2;
            _order.Quantity = 10;

            _productService
               .Setup(v => v.UpdateOrder(_order))
               .Returns("Order Updated");

            var result = _service.AddOrder(_order);
            Assert.That(result, Is.EqualTo("Order Updated"));
            _productService.VerifyAll();
        }

        [Test]
        public void ValidateDeleteOrder_GivenValidInput_ReturnsData()
        {
            Order _order = new Order();
            _order.ProductId = 2;
            _order.Quantity = 10;

            _productService
               .Setup(v => v.DeleteOrder(_order))
               .Returns("Order Removed");

            var result = _service.AddOrder(_order);
            Assert.That(result, Is.EqualTo("Order Removed"));
            _productService.VerifyAll();
        }
    }
}
