using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingCorners.Validation;
using Core.Utilittes.BusinessRules;
using Core.Utilittes.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;

        }
        [SecuredOperation("product.add")]
        [ValidationAspect(typeof(ProductValidator))]
        
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitedExist());

            if (result != null)
            {
                return result;
            }

            try
            {
                _productDal.Add(product);
                int insertedItemId = product.ProductID;

                return new SuccessResult(Messages.ProductAdded, insertedItemId);
            }
            catch (Exception)
            {
                return new ErrorResult("Urun Adi Mevcut");

            }


        }



        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 25)
            {
                return new ErrorDataResult<List<Product>>("Bakim Saati");
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Urunler Listelendi");
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<ProductDetails>> ProductDetails()
        {
            return new SuccessDataResult<List<ProductDetails>>(_productDal.ProductDetails());
        }

        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryID == product.CategoryID).Count;
            if (result >= 10)
            {
                return new ErrorResult("Urun Mevcut");
            }
            throw new NotImplementedException();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        public IResult CheckIfCategoryLimitedExist()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count > 15)
            {
                return new ErrorResult("Hata");
            }
            return new SuccessResult(); 
        }

    }
}
