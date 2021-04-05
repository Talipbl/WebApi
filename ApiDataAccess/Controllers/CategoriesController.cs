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
    public class CategoriesController : ApiController
    {
        NorthwindEntities _db = new NorthwindEntities();
        [HttpGet]
        public List<CategoryDTO> Get()
        {
            return _db.Categories.Select(x => new CategoryDTO
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName
            }).ToList();
        }
    }
}
