using DataModelEntities;
using DtoEntities;
using Service.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Mappers
{
    public class OrderDetailMapper : IOrderDetailMapper
    {
        public OrderDetailMapper() { }

        public OrderDetailDTO getDTO(OrderDetail orderDetail)
        {
            OrderDetailDTO dto = new OrderDetailDTO();
            dto.OrderDetailId = orderDetail.OrderDetailId;
            dto.OrderId = orderDetail.OrderId;
            dto.ProductId = orderDetail.ProductId;
            dto.Quantity = orderDetail.Quantity;
            dto.SubTotal = orderDetail.SubTotal;
            dto.Timestamp = orderDetail.Timestamp;
            return dto;
        }

        public OrderDetail getEntity(OrderDetailDTO dto)
        {
            OrderDetail orderDetail = new OrderDetail();
            orderDetail.OrderDetailId = dto.OrderDetailId;
            orderDetail.OrderId = dto.OrderId;
            orderDetail.ProductId = dto.ProductId;
            orderDetail.Quantity = dto.Quantity;
            orderDetail.SubTotal = dto.SubTotal;
            orderDetail.Timestamp = dto.Timestamp;
            return orderDetail;
        }

        public List<OrderDetailDTO> getDTOs(List<OrderDetail> orderDetails)
        {
            List<OrderDetailDTO> dtos = new List<OrderDetailDTO>();
            orderDetails.ForEach(p => dtos.Add(getDTO(p)));
            return dtos;
        }

        public List<OrderDetail> getEntities(List<OrderDetailDTO> dtos)
        {
            List<OrderDetail> orders = new List<OrderDetail>();
            dtos.ForEach(p => orders.Add(getEntity(p)));
            return orders;
        }
    }
}
