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
        public async Task<List<Product>> GetProducts()
        {
            string currentUrl = $"{_url}get";
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(currentUrl);
            if (response.IsSuccessStatusCode)
            {
                List<Product> products = await response.Content.ReadAsAsync<List<Product>>();
                return products;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public async Task<Product> GetProduct(int id)
        {
            string currentUrl = $"{_url}get/{id}";
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(currentUrl);
            if (response.IsSuccessStatusCode)
            {
                Product product = await response.Content.ReadAsAsync<Product>();
                return product;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<bool> AddProduct(Product product)
        {
            string currentUrl = $"{_url}post";
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync(currentUrl, product);
            return response.IsSuccessStatusCode;

        }
        public async Task<bool> UpdateProduct(Product product)
        {
            string currentUrl = $"{_url}put";
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync(currentUrl, product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            string currentUrl = $"{_url}delete?id={id}";
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(currentUrl);
            return response.IsSuccessStatusCode;
        }
    }
}
