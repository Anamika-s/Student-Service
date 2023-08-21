using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductIActionResultController : ControllerBase
    {
        static List<Product> products = null;

        public ProductIActionResultController()
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
        public IActionResult Get()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            Product product=  products.FirstOrDefault(x => x.Id == id);
        if(product==null)
                return NotFound();
        else 
                return Ok(product);
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            products.Add(product);
            return Created("Record hsa been inserted", product);
        }
        [HttpPut("{id}")]
        public IActionResult EditProduct(int id, Product product)
        {
            Product obj =  products.FirstOrDefault(x => x.Id == id);
            if (obj == null)

                return NotFound();
            else
            {
                foreach (Product temp in products)
                {
                    if (obj.Id == id)
                    {
                        obj.Description = product.Description;
                        obj.QtyStock = product.QtyStock;
                    }
                }
                return Ok(obj);
            }
            }
        

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            Product obj = products.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                products.Remove(obj);
                return Ok("product has been deleted");
            }
            else 
                return NotFound();
            }
        }

    }

