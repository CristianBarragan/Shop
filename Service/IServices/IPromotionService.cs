using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IPromotionService
    {
        PromotionDTO addPromotion(PromotionDTO  promotion);
        void updatePromotion(PromotionDTO promotion);
        void deletePromotion(long promotionId);
        PromotionDTO getPromotion(long promotionId);
        List<PromotionDTO> getPromotions();
        List<PromotionDTO> getPromotions(long productId);
    }
}
