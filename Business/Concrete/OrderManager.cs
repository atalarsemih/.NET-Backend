using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderdal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderdal = orderDal;
        }
        public List<Order> GetAll()
        {
           return _orderdal.GetAll();
        }
    }
}
