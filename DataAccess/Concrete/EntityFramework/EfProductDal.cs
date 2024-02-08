using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using Entites.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, DatabaseContext>, IProductDal
    {
        public int AddAndGetId(Product product)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetails> ProductDetails()
        {
            using(DatabaseContext context = new DatabaseContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.ProductID equals c.CategoryId
                             select new ProductDetails {Id = p.ProductID,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName, 
                                 UnitsInStock = p.UnitsInStock, };
                return result.ToList();
            }
        }
    }
}
