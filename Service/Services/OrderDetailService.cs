using DomainModel;
using DtoEntities;
using Service.IMappers;
using Service.IServices;
using Shop.WebApi.Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        IOrderDetailDataAccessProvider orderDetailDataAccessProvider;
        IOrderDataAccessProvider orderDataAccessProvider;
        IOrderDetailMapper mapper;

        public OrderDetailService(IOrderDetailDataAccessProvider orderDetailDataAccessProvider,
                                  IOrderDataAccessProvider orderDataAccessProvider,
                              IOrderDetailMapper mapper)
        {
            this.orderDetailDataAccessProvider = orderDetailDataAccessProvider;
            this.orderDataAccessProvider = orderDataAccessProvider;
            this.mapper = mapper;
        }

        public OrderDetailDTO addOrderDetail(OrderDetailDTO orderDetail)
        {
            if(orderDataAccessProvider.GetOrder(orderDetail.OrderId) == null)
                throw new BusinessException("Order does not exist");
            else if (orderDetailDataAccessProvider.GetOrderDetails(od => od.OrderId == orderDetail.OrderId && od.OrderDetailId == orderDetail.OrderDetailId, true).Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Order detail already exists in order ");
                sb.Append(orderDetail.OrderId);
                throw new BusinessException(sb.ToString());
            }
            else
                return mapper.getDTO(orderDetailDataAccessProvider.AddOrderDetail(mapper.getEntity(orderDetail)));
        }

        public void updateOrderDetail(OrderDetailDTO orderDetail)
        {
            orderDetailDataAccessProvider.UpdateOrderDetail(mapper.getEntity(orderDetail));
        }

        public void deleteOrderDetail(long orderDetailId)
        {
            orderDetailDataAccessProvider.DeleteOrderDetail(orderDetailId);
        }

        public OrderDetailDTO getOrderDetail(long orderDetailId)
        {
            return mapper.getDTO(orderDetailDataAccessProvider.GetOrderDetail(orderDetailId));
        }
    }
}
