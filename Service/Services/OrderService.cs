using DomainModel;
using DtoEntities;
using Service.IMappers;
using Service.IServices;
using Shop.WebApi.Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        IOrderDataAccessProvider orderDataAccessProvider;
        IOrderMapper mapper;

        public OrderService(IOrderDataAccessProvider orderDataAccessProvider,
                              IOrderMapper mapper)
        {
            this.orderDataAccessProvider = orderDataAccessProvider;
            this.mapper = mapper;
        }

        public OrderDTO addOrder(OrderDTO order)
        {
            if (orderDataAccessProvider.GetOrders(o => o.OrderId == order.OrderId, false).Any())
                throw new BusinessException("Order Id already exists");
            return mapper.getDTO(orderDataAccessProvider.AddOrder(mapper.getEntity(order)));
        }

        public void updateOrder(OrderDTO order)
        {
            orderDataAccessProvider.UpdateOrder(mapper.getEntity(order));
        }

        public void deleteOrder(long orderId)
        {
            orderDataAccessProvider.DeleteOrder(orderId);
        }

        public OrderDTO getOrder(long OrderId)
        {
            return mapper.getDTO(orderDataAccessProvider.GetOrder(OrderId));
        }

        public List<OrderDTO> getOrders()
        {
            return mapper.getDTOs(orderDataAccessProvider.GetOrders(x => true, true));
        }
    }
}
