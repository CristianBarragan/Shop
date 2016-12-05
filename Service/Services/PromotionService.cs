using DataModelEntities;
using DomainModel;
using DtoEntities;
using Service.IMappers;
using Service.IServices;
using Shop.WebApi.Handling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Service.Services
{
    public class PromotionService : IPromotionService
    {
        IPromotionDataAccessProvider promotionDataAccessProvider;
        IPromotionMapper mapper;

        public PromotionService(IPromotionDataAccessProvider promotionDataAccessProvider,
                              IPromotionMapper mapper)
        {
            this.promotionDataAccessProvider = promotionDataAccessProvider;
            this.mapper = mapper;
        }

        public PromotionDTO addPromotion(PromotionDTO promotion)
        {
            if (promotionDataAccessProvider.GetPromotions(p => p.ProductId == promotion.ProductId && p.Quantity == promotion.Quantity).Any())
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("A product promotion exists with quantity ");
                sb.Append(promotion.Quantity.ToString());
                throw new BusinessException(sb.ToString());
            }
            else
                return mapper.getDTO(promotionDataAccessProvider.AddPromotion(mapper.getEntity(promotion)));
        }

        public void updatePromotion(PromotionDTO promotion)
        {
            promotionDataAccessProvider.UpdatePromotion(mapper.getEntity(promotion));
        }

        public void deletePromotion(long promotionId)
        {
            promotionDataAccessProvider.DeletePromotion(promotionId);
        }

        public PromotionDTO getPromotion(long promotionId)
        {
            return mapper.getDTO(promotionDataAccessProvider.GetPromotion(promotionId));
        }

        public List<PromotionDTO> getPromotions()
        {
            return mapper.getDTOs(promotionDataAccessProvider.GetPromotions(x => true));
        }

        public List<PromotionDTO> getPromotions(long productId)
        {
            return mapper.getDTOs(promotionDataAccessProvider.GetPromotions(x => x.ProductId == productId));
        }
    }
}
