using DataModelEntities;
using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IMappers
{
    public interface IPromotionMapper
    {
        PromotionDTO getDTO(Promotion entity);
        Promotion getEntity(PromotionDTO dto);
        List<PromotionDTO> getDTOs(List<Promotion> entities);
        List<Promotion> getEntities(List<PromotionDTO> dtos);
    }
}
