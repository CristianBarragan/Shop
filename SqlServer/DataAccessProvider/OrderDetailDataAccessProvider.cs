using DataModelEntities;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SqlServer.DomainContext
{
    public class OrderDetailDataAccessProvider : IOrderDetailDataAccessProvider
    {
        private readonly DomainModelContext context;
        private readonly ILogger logger;

        public OrderDetailDataAccessProvider(DomainModelContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            logger = loggerFactory.CreateLogger("DataAccessMSQL");
        }

        public OrderDetail AddOrderDetail(OrderDetail orderDetail)
        {
            context.OrderDetails.Add(orderDetail);
            context.SaveChanges();
            return orderDetail;
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            context.OrderDetails.Update(orderDetail);
            context.SaveChanges();
        }

        public void DeleteOrderDetail(long orderDetailId)
        {
            var entity = context.OrderDetails.First(t => t.OrderDetailId == orderDetailId);
            context.OrderDetails.Remove(entity);
            context.SaveChanges();
        }

        public OrderDetail GetOrderDetail(long orderDetailId)
        {
            return context.OrderDetails.Include(o => o.order).First(t => t.OrderDetailId == orderDetailId);
        }

        public List<OrderDetail> GetOrderDetails(Func<OrderDetail, bool> predicate, bool order)
        {
            if(order)
                return context.OrderDetails.Include(o => o.order).Where(predicate).ToList();
            else
                return context.OrderDetails.Where(predicate).ToList();
        }
    }
}
