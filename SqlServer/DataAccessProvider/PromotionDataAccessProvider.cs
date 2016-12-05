using DataModelEntities;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SqlServer.DomainContext
{
    public class PromotionDataAccessProvider : IPromotionDataAccessProvider
    {
        private readonly DomainModelContext context;
        private readonly ILogger logger;

        public PromotionDataAccessProvider(DomainModelContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            logger = loggerFactory.CreateLogger("DataAccessMSQL");
        }

        public Promotion AddPromotion(Promotion promotion)
        {
            context.Promotions.Add(promotion);
            context.SaveChanges();
            return promotion;
        }

        public void UpdatePromotion(Promotion promotion)
        {
            context.Promotions.Update(promotion);
            context.SaveChanges();
        }

        public void DeletePromotion(long promotionId)
        {
            var entity = context.Promotions.First(t => t.PromotionId == promotionId);
            context.Promotions.Remove(entity);
            context.SaveChanges();
        }

        public Promotion GetPromotion(long promotionId)
        {
            return context.Promotions.First(t => t.PromotionId == promotionId);
        }

        public List<Promotion> GetPromotions(Func<Promotion, bool> predicate)
        {
            return context.Promotions.OrderByDescending(predicate).ToList();
        }
    }
}
