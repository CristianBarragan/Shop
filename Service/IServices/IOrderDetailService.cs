using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IOrderDetailService
    {
        OrderDetailDTO addOrderDetail(OrderDetailDTO orderDetail);
        void updateOrderDetail(OrderDetailDTO orderDetail);
        void deleteOrderDetail(long orderDetailId);
        OrderDetailDTO getOrderDetail(long orderDetailId);
    }
}
