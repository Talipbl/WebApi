using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WfaUi.ApiConfig;

namespace WfaUi.Models.ApiProcessors
{
    class ProductProcessor
    {
        string _url = "https://localhost:44339/api/products/";
        public async List<Product> GetProducts()
        {
            string currentUrl = $"{_url}get";
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(currentUrl);
        }
        public Product GetProduct(int id)
        {
            string activeUrl = $"{_url}get/{id}";
        }

        public bool AddProduct(Product product)
        {

        }
        public bool UpdateProduct(Product product)
        {

        }
        public bool DeleteProduct(int id)
        {

        }
    }
}
