using DataModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IPromotionDataAccessProvider
    {
        Promotion AddPromotion(Promotion promotion);
        void UpdatePromotion(Promotion promotion);
        void DeletePromotion(long promotionId);
        Promotion GetPromotion(long promotionId);
        List<Promotion> GetPromotions(Func<Promotion, bool> predicate);
    }
}