using Shop.Domain.DTOs.Order;

namespace Shop.Domain.Interfaces
{
    public interface IOrderService
    {
        #region Order
        Task<int> AddOrder(CreateOrderDto order);
        Task<OrderDto> GetOrderDetailById(int Id);
        Task<bool> DeleteOrder(int id);

        #endregion

    }
}
