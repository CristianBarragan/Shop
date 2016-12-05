using DataModelEntities;
using DtoEntities;
using Service.IMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Mappers
{
    public class PromotionMapper : IPromotionMapper
    {
        public PromotionMapper() { }

        public PromotionDTO getDTO(Promotion promotion)
        {
            PromotionDTO dto = new PromotionDTO();
            dto.PromotionId = promotion.PromotionId;
            dto.ProductId = promotion.ProductId;
            dto.Quantity = promotion.Quantity;
            dto.Discount = promotion.Discount;
            dto.Timestamp = promotion.Timestamp;
            return dto;
        }

        public Promotion getEntity(PromotionDTO dto)
        {
            Promotion promotion = new Promotion();
            promotion.PromotionId = dto.PromotionId;
            promotion.ProductId = dto.ProductId;
            promotion.Quantity = dto.Quantity;
            promotion.Discount = dto.Discount;
            promotion.Timestamp = dto.Timestamp;
            return promotion;
        }

        public List<PromotionDTO> getDTOs(List<Promotion> promotions)
        {
            List<PromotionDTO> dtos = new List<PromotionDTO>();
            promotions.ForEach(p => dtos.Add(getDTO(p)));
            return dtos;
        }

        public List<Promotion> getEntities(List<PromotionDTO> dtos)
        {
            List<Promotion> promotions = new List<Promotion>();
            dtos.ForEach(p => promotions.Add(getEntity(p)));
            return promotions;
        }
    }
}
