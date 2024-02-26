
using Shop.Domain.Models.Order;

namespace Shop.Domain.Interfaces
{
    public interface IOrderDetailRepository
    {
        Task AddOrderDetail(Order Order);
        Task<Order> GetOrderDetailById(int id);
        Task<List<Order>> GetAllOrderDetail();
        void UpdateOrderDetail(Order order);
        Task SaveChanges();
    }
}
