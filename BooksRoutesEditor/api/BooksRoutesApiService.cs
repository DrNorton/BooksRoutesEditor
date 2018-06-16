using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BooksRoutesEditor.api.Models;
using RestSharp;

namespace BooksRoutesEditor.api
{
    public class BooksRoutesApiService
    {
        private RestClient _client;

        public BooksRoutesApiService()
        {
            _client = new RestClient(@"http://booksroutes-api.azurewebsites.net");
            
        }

        public async Task<List<Book>> GetBooks()
        {
            var request = new RestRequest("api/v1/books", Method.GET);
            var queryResult = await _client.ExecuteTaskAsync<ApiResponse<List<Book>>>(request);
            if (queryResult.IsSuccessful)
            {
                var response = queryResult.Data;
                if (response.status == "success")
                {
                    return response.data;
                }
                else
                {
                    throw new Exception(response.message);
                }
            }
            else
            {
                throw new Exception("произошла ошибка");
            }
        }
    }
}
