using DataModelEntities;
using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IMappers
{
    public interface IOrderMapper
    {
        OrderDTO getDTO(Order entity);
        Order getEntity(OrderDTO dto);
        List<OrderDTO> getDTOs(List<Order> entities);
        List<Order> getEntities(List<OrderDTO> dtos);
    }
}
