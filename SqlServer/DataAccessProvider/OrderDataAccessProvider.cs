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
    public class OrderDataAccessProvider : IOrderDataAccessProvider
    {
        private readonly DomainModelContext context;
        private readonly ILogger logger;

        public OrderDataAccessProvider(DomainModelContext context, ILoggerFactory loggerFactory)
        {
            this.context = context;
            logger = loggerFactory.CreateLogger("DataAccessMSQL");
        }

        public Order AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        public void UpdateOrder(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }

        public void DeleteOrder(long orderId)
        {
            var entity = context.Orders.First(t => t.OrderId == orderId);
            context.Orders.Remove(entity);
            context.SaveChanges();
        }

        public Order GetOrder(long orderId)
        {
            return context.Orders.First(t => t.OrderId == orderId);
        }

        public List<Order> GetOrders(Func<Order, bool> predicate, bool details)
        {
            if(details)
                return context.Orders.Include(o => o.details).Where(predicate).ToList();
            else
                return context.Orders.Where(predicate).ToList();
        }

        public List<OrderDetail> GetOrderDetails(long orderId)
        {
            return context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }
    }
}
