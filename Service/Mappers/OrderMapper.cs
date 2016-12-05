using DataModelEntities;
using DtoEntities;
using Service.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Mappers
{
    public class OrderMapper : IOrderMapper
    {
        public OrderMapper() { }

        public OrderDTO getDTO(Order order)
        {
            OrderDTO dto = new OrderDTO();
            dto.OrderId = order.OrderId;
            dto.date = order.date;
            dto.total = order.total;
            dto.Timestamp = order.Timestamp;
            return dto;
        }

        public Order getEntity(OrderDTO dto)
        {
            Order order = new Order();
            order.OrderId = dto.OrderId;
            order.date = dto.date;
            order.total = dto.total;
            order.Timestamp = dto.Timestamp;
            return order;
        }

        public List<OrderDTO> getDTOs(List<Order> orders)
        {
            List<OrderDTO> dtos = new List<OrderDTO>();
            orders.ForEach(p => dtos.Add(getDTO(p)));
            return dtos;
        }

        public List<Order> getEntities(List<OrderDTO> dtos)
        {
            List<Order> orders = new List<Order>();
            dtos.ForEach(p => orders.Add(getEntity(p)));
            return orders;
        }
    }
}
