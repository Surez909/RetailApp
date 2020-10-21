using DBLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using WebApiApplication;

namespace WebApi.Controllers
{
    public class ProductController : ApiController
    {

        //private readonly IProductService _productService;
        public IProductService _productService { get; set; }

        public ProductController()
        {
            _productService = new ProductService();
        }
        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [System.Web.Http.Route("product/getproducts")]
        [System.Web.Http.HttpGet]
        public JsonResult<List<Product>> GetProducts()
        {
            return Json<List<Product>>(_productService.GetProducts());
        }

        [System.Web.Http.Route("product/addorder")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage AddOrder(Order _order)
        {
            var results =_productService.AddOrder(_order);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(results, Encoding.UTF8, "application/json");
            return response;
        }

        [System.Web.Http.Route("product/updateorder")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage UpdateOrder(Order _order)
        {
            var results = _productService.UpdateOrder(_order);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(results, Encoding.UTF8, "application/json");
            return response;
        }

        [System.Web.Http.Route("product/removeorder")]
        [System.Web.Http.HttpPost]
        public HttpResponseMessage RemoveOrder(Order _order)
        {
            var results = _productService.DeleteOrder(_order);
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(results, Encoding.UTF8, "application/json");
            return response;
        }
    }
}
