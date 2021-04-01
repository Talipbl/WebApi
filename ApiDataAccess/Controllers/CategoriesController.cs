using ApiDataAccess.Models;
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
        
    }
}
