using DataModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IOrderDetailDataAccessProvider
    {
        OrderDetail AddOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(long orderDetail_id);
        OrderDetail GetOrderDetail(long orderDetail_id);
        List<OrderDetail> GetOrderDetails(Func<OrderDetail, bool> predicate, bool order);
    }
}
