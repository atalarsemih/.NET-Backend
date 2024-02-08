using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilittes.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _productService.GetAll();

            if (result.Success)
            {
                return Ok(new { Data = result.Data, Success = true});
            }

            return BadRequest(new { Data = result.Data, Success = false, Message = result.Message });
        }



        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);

            if (result.Success)
            {
                return Ok(new
                {
                    data = result.Data,success = true,
                });
            }

            return BadRequest(new { Message = result.Message });
        }







        [HttpPost]
        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult("Urun Ismi Geceersiz");
                
               
            }

            try
            {
                _productService.Add(product);
                object data = product;
                int insertedItemId = product.ProductID;
                
                
                

                return new SuccessResult(Messages.ProductAdded)
                {
                    Data = data,
                    InsertedItemId = insertedItemId,
                    
                    
                };
            }
            catch (Exception)
            {
                return new ErrorResult("Urun Ismi Gecersiz");
            }
        }




    }
}
