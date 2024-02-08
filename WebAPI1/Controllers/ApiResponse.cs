using Entites.Concrete;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace WebAPI1.Controllers
{
    internal class ApiResponse<T> : ModelStateDictionary
    {
        public bool Success { get; set; }
        public List<Product> Data { get; set; }
        public string Message { get; set; }
    }
}