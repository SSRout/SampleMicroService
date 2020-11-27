using MvcWebApp.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MvcWebApp.ServicesProxy
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;

        public TransferService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Transfer(TransferDto transferDto)
        {
            //var uri = "http://localhost:8000/api/Banking";//dockerise url
            var uri = "https://localhost:5001/api/Banking";
            var content = new StringContent(JsonSerializer.Serialize(transferDto),Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}
