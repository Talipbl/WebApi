using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WfaUi.ApiConfig;

namespace WfaUi.Models.ApiProcessors
{
    class CategoryProcessor
    {
        string _url= "https://localhost:44339/api/categories/";
        public async Task<List<Category>> GetCategories()
        {
            string currentUrl = $"{_url}get";
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(currentUrl); 
            if (response.IsSuccessStatusCode)
            {
                List<Category> categories= await response.Content.ReadAsAsync<List<Category>>();
                return categories;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
