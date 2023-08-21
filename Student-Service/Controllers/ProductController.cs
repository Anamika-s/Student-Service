using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        static List<Product> products = null;

        public ProductController()
        {
            if(products==null)
            {
                products = new List<Product>()
                {
                    new Product(){ Id=1,Name="Mouse", Description="Gray in color", QtyStock=9},

                    new Product(){ Id=2,Name="Scanner", Description="Gray in color", QtyStock=10}
                };
            }

        }
        [HttpGet]
        public List<Product> Get()
        {
            return products;
        }

        [HttpGet("{id}")]
        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public void AddProduct(Product product)
        {
            products.Add(product);
        }
        [HttpPut("{id}")]
        public void EditProduct(int id, Product product)
        {
            Product obj =  products.FirstOrDefault(x => x.Id == id);
            if(obj!=null)
            {
                foreach(Product temp in products)
                {
                    if(obj.Id==id)
                    {
                        obj.Description = product.Description;
                        obj.QtyStock = product.QtyStock;
                    }
                }
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            Product obj = products.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                products.Remove(obj);

            }
        }

    }
}
