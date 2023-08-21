using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductActionResultController : ControllerBase
    {
        static List<Product> products = null;

        public ProductActionResultController()
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
        public ActionResult<List<Product>> Get()
        {
            if (products == null)
                return BadRequest();
            else
            return products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            Product product=  products.FirstOrDefault(x => x.Id == id);
        if(product==null)
                return NotFound();
        else 
                return product;
        }
        [HttpPost]
        public ActionResult<int> AddProduct(Product product)
        {
            products.Add(product);
            return 1;
            //return Created("Record hsa been inserted", product);
        }
        [HttpPut("{id}")]
        public ActionResult<Product> EditProduct(int id, Product product)
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
        public ActionResult<bool> DeleteProduct(int id)
        {
            Product obj = products.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                products.Remove(obj);
                return true;
            }
            else 
                return NotFound();
            }
        }

    }

