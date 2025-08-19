using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.enums;
using ProvaPub.Services.Interfaces;
using ProvaPub.Services.Payments;

namespace ProvaPub.Services;

public class OrderService : IOrderService
{
    private static readonly TimeZoneInfo BrasiliaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
    private readonly TestDbContext _ctx;
    private readonly PaymentStrategyFactory _paymentFactory;
    private readonly IDateTimeUtils _clock;


    public OrderService(TestDbContext ctx, PaymentStrategyFactory paymentFactory, IDateTimeUtils clock)
    {
        _ctx = ctx;
        _paymentFactory = paymentFactory;
        _clock = clock;
    }

    public async Task<Order> PayOrder(PaymentType paymentMethod, decimal paymentValue, int customerId)
    {
        var strategy = _paymentFactory.GetStrategy(paymentMethod);
        await strategy.Pay(paymentValue, customerId);

        return await InsertOrder(new Order()
        {
            Value = paymentValue,
            OrderDate = _clock.UtcNow
        });
    }

    public async Task<Order> InsertOrder(Order order)
    {
        //Insere pedido no banco de dados
        var result = (await _ctx.Orders.AddAsync(order)).Entity;
        result.OrderDate = TimeZoneUtils.ToBrasiliaTime(order.OrderDate);
        return result;
    }
}
