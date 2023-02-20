using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = 1,
                Name = "Product 1",
                Price = 1000,
                Size = "M"
            },
            new Product()
            {
                Id = 2,
                Name = "Product 2",
                Price = 2000,
                Size = "XL"
            }
        };

        [HttpGet]
        [Route("DisplayAll")]
        public ActionResult<Product> GetAllProducts()
        {
            return Ok(products);
        }

        [HttpPost]
        [Route("AddProduct")]
        public ActionResult<Product> AddProduct(Product request)
        {
            products.Add(request);
            return Ok(products);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult<Product> UpdateProduct(Product request)
        {
            var product = products.Find(x => x.Id == request.Id);
            if (product == null)
                return BadRequest("Product ID not found");

            product.Name = request.Name;
            product.Price = request.Price;
            product.Size = request.Size;
            return Ok(products);
        }

        [HttpDelete]
        [Route("RemoveProduct")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = products.Find(x => x.Id == id);
            if (product == null)
                return BadRequest("Product ID not found");

            products.Remove(product);
            return Ok(products);
        }


    }
}
