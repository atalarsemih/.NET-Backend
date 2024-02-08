
using Core.Utilittes.Results;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<ProductDetails>> ProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);


    }
}
