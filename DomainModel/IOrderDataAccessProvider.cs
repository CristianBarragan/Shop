using DataModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IOrderDataAccessProvider
    {
        Order AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(long orderId);
        Order GetOrder(long orderId);
        List<Order> GetOrders(Func<Order, bool> predicate, bool details);
        List<OrderDetail> GetOrderDetails(long orderId);        
    }
}
