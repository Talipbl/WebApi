using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiDataAccess.Models.DataTransferObjects
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}