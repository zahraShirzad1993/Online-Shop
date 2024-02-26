using Microsoft.EntityFrameworkCore;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Order;
using Shop.Domain.Models.OrderEntity;
using Shop.Infra.Data.Context;

namespace Shop.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        #region constractor
        private readonly ShopDbContext _context;
        public OrderRepository(ShopDbContext context)
        {
            _context = context;
        }
        #endregion

        public async Task<Order> CheckUserOrder(int userId)
        {
            return await _context.Orders.AsQueryable()
                .FirstOrDefaultAsync(c => c.UserId == userId && !c.IsFinaly);
        }
        public async Task AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<OrderDetail> CheckOrderDetail(int orderId, int productId)
        {
            return await _context.OrderDetails.AsQueryable()
                .Where(c => c.OrderId == orderId && c.ProductId == productId && !c.IsDelete)
                .FirstOrDefaultAsync();
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _context.Orders.AsQueryable()
                .SingleOrDefaultAsync(c => c.Id == orderId);
        }

        public async Task<Order> GetOrderDetailById(int orderId)
        {
            return await _context.Orders.AsQueryable().Include(a => a.OrderDetail)
                .SingleOrDefaultAsync(c => c.Id == orderId);
        }

        public async Task<bool> DeleteOrder(int Id)
        {
            var Order = await _context.Orders.AsQueryable()
                 .Where(c => c.Id == Id).FirstOrDefaultAsync();

            var OrderDetail = await _context.OrderDetails.AsQueryable()
                 .Where(c => c.OrderId == Id).FirstOrDefaultAsync();

            if (Order != null)
            {
                Order.IsDelete = true;
                _context.Orders.Update(Order);
                await _context.SaveChangesAsync();
                return true;
            }
            if (OrderDetail != null)
            {
                OrderDetail.IsDelete = true;
                _context.OrderDetails.Update(OrderDetail);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
        }
    }
}
