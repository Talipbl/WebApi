using ApiDataAccess.Models;
using ApiDataAccess.Models.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDataAccess.Controllers
{
    public class ProductsController : ApiController
    {
        NorthwindEntities _db = new NorthwindEntities();
        [HttpGet]
        public List<ProductDTO> Get()
        {
            return _db.Products.Select(x => new ProductDTO
            {
                ProductID = x.ProductID,
                CategoryId = x.CategoryID,
                ProductName = x.ProductName,
                CategoryName = x.Category.CategoryName,
                UnitPrice = (decimal)x.UnitPrice,
                UnitsInStock = (short)x.UnitsInStock
                
            }).ToList();
        }

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            Product addedProduct = new Product()
            {
                ProductID = product.ProductID,
                CategoryID = product.CategoryID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };

            _db.Entry<Product>(addedProduct).State = System.Data.Entity.EntityState.Added;
            if (_db.SaveChanges()>0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _db.Entry<Product>(_db.Products.Find(id)).State = System.Data.Entity.EntityState.Deleted;
            if (_db.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public IHttpActionResult Put(Product product)
        {
            Product updatedProduct = new Product()
            {
                ProductID = product.ProductID,
                CategoryID = product.CategoryID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock
            };

            _db.Entry<Product>(updatedProduct).State = System.Data.Entity.EntityState.Modified; 
            if (_db.SaveChanges() > 0)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
