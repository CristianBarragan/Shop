using DtoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IOrderService
    {
        OrderDTO addOrder(OrderDTO product);
        void updateOrder(OrderDTO product);
        void deleteOrder(long productId);
        OrderDTO getOrder(long ProductId);
        List<OrderDTO> getOrders();
    }
}
