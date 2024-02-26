using Shop.Domain.DTOs.Order;
using Shop.Domain.DTOs.OrderDetails;
using Shop.Domain.Interfaces;
using Shop.Domain.Models.Enums;
using Shop.Domain.Models.Order;
using Shop.Domain.Models.OrderEntity;



namespace Shop.Appliation.Services
{
    public class OrderService : IOrderService
    {
        #region constractor
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)//
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        #endregion

        #region order
        public async Task<int> AddOrder(CreateOrderDto ordermodel)
        {
            await CheckOrderTime();
            await CheckUserOrder(ordermodel.UserId);

            Order order = new()
            {
                UserId = ordermodel.UserId,
                DeliveryDateTime = ordermodel.DeliveryDateTime,
                Description = ordermodel.Description,
                IsDelete = false,
                IsFinaly = false,
                OrderState = OrderState.Processing,
                DiscountAmount = ordermodel.DiscountAmount,
                DiscountType = ordermodel.DiscountType,
            };
            var prodcts = await _productRepository.GetProductsAsync(ordermodel.OrderDetailDto.Select(x => (int)x.ProductId).ToList<int>());

            order.OrderDetail = ordermodel.OrderDetailDto.Select(a => new OrderDetail()
            {
                ProductId = a.ProductId,
                OrderQty = a.OrderQty,
                UnitPrice = prodcts.First(b => b.Id == a.ProductId).UnitPrice + (a.Benefit ? prodcts.First(b => b.Id == a.ProductId).benefitPrcie : 0)

            }).ToList();
            order.TotalPrice = order.OrderDetail.Select(a => new { total = a.UnitPrice * a.OrderQty }).Sum(a => a.total);

            await CalculateDisount(order, ordermodel);
            await CheckTotalPrice(order.TotalPrice);

            return (await CreateOrder(order).ConfigureAwait(false)).Id;
        }

        public async Task EditOrder(EditOrderDto ordermodel)
        {
            var dbOrder = await _orderRepository.GetOrderById(ordermodel.Id);

            //if(dbOrder == null)
            //    throw new ex

            await CheckOrderTime();
            dbOrder.DeliveryDateTime = ordermodel.DeliveryDateTime;
            dbOrder.Description = ordermodel.Description;
            await UpdateOrder(dbOrder);
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            return await _orderRepository.GetOrderById(orderId);
        }


        #endregion

        #region private
        private async Task CheckOrderTime()
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            if (!(currentTime.Hours >= 8 && currentTime.Hours <= 19))
                throw new Exception("در این بازه امکان ثبت سقاش جد نداد");


        }
        private async Task CheckUserOrder(int userId)
        {
            if ((await _orderRepository.CheckUserOrder(userId)) != null)
                throw new Exception("در این بازه امکان ثبت سقاش جد نداد");

        }
        private async Task CheckTotalPrice(decimal totalPrice)
        {
            const decimal MinTotalPrice = (decimal)500.000;
            if (totalPrice < MinTotalPrice)
                throw new Exception();
        }
        private async Task<Order> CalculateDisount(Order order, CreateOrderDto ordermodel)
        {
            if ((ordermodel.DiscountAmount > 0 && ordermodel.DiscountType.HasValue))
            {
                switch (ordermodel.DiscountType)
                {
                    case DiscountType.Percent:
                        order.TotalPrice = order.TotalPrice - ((decimal)ordermodel.DiscountAmount / 100);
                        break;
                    case DiscountType.cash:
                        order.TotalPrice = order.TotalPrice - (decimal)ordermodel.DiscountAmount;
                        break;
                }

            }
            return order;
        }
        private async Task<Order> CreateOrder(Order order)
        {
            await _orderRepository.AddOrder(order);
            await _orderRepository.SaveChanges();
            return order;
        }

        private async Task UpdateOrder(Order order)
        {
            await _orderRepository.UpdateOrder(order);
            await _orderRepository.SaveChanges();
        }
        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderRepository.DeleteOrder(id);
        }

        public async Task<OrderDto> GetOrderDetailById(int Id)
        {
            var orderModel = await _orderRepository.GetOrderDetailById(Id);

            return new OrderDto()
            {
                DeliveryDateTime = orderModel.DeliveryDateTime,
                DiscountType = orderModel.DiscountType,
                DiscountAmount = orderModel.DiscountAmount,
                Description = orderModel.Description,
                IsActive = orderModel.IsActive,
                IsFinaly = orderModel.IsFinaly,
                OrderState = orderModel.OrderState,
                TotalPrice = orderModel.TotalPrice,
                OrderDetail = orderModel.OrderDetail?.Select(a => new EditOrderDetailDto()
                {
                    Id = a.Id,
                    OrderId = a.OrderId,
                    OrderQty = a.OrderQty,
                    ProductId = a.ProductId,
                    UnitPrice = a.UnitPrice,
                    UnitPriceDiscount = a.UnitPriceDiscount,
                    Prodcut = a.Prodcut?.Select(b => new Domain.DTOs.Product.EditProductDto()
                    {
                        Description = b.Description,
                        Name = b.Name,
                        productCategoryId = b.productCategoryId,
                        ProductId = b.Id,
                        UnitPrice = b.UnitPrice,
                    }).ToList()
                }).ToList(),
            };
        }
        #endregion
    }
}
