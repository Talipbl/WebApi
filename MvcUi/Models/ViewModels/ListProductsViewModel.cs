using ApiDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcUi.Models.ViewModels
{
    public class ListProductsViewModel
    {
        public List<Product> Products{ get; set; }
    }
}