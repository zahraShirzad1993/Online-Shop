using Shop.Domain.DTOs.Order;
using Shop.Domain.Models.Order;
using Shop.Domain.Models.OrderEntity;

namespace Shop.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CheckUserOrder(int userId);
        Task AddOrder(Order order);
        Task SaveChanges();
        Task<Order> GetOrderById(int orderId);
        Task<Order> GetOrderDetailById(int orderId);
        Task UpdateOrder(Order order);
        Task<OrderDetail> CheckOrderDetail(int orderId, int productId);
        Task<bool> DeleteOrder(int Id);
    }
}
