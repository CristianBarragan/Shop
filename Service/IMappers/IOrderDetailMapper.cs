using DataModelEntities;
using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IMappers
{
    public interface IOrderDetailMapper
    {
        OrderDetailDTO getDTO(OrderDetail entity);
        OrderDetail getEntity(OrderDetailDTO dto);
        List<OrderDetailDTO> getDTOs(List<OrderDetail> entities);
        List<OrderDetail> getEntities(List<OrderDetailDTO> dtos);
    }
}
