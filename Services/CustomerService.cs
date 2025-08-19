using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services;

public class CustomerService : PageService<Customer>, ICustomerService
{
    private readonly IDateTimeUtils _clock;
    public CustomerService(TestDbContext ctx, IDateTimeUtils clock) : base(ctx)
    {
        _clock = clock;
    }

    public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
    {
        if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

        if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

        //Business Rule: Non registered Customers cannot purchase
        var customer = await _ctx.Customers.FindAsync(customerId) 
            ?? throw new InvalidOperationException($"Customer Id {customerId} does not exists");

        //Business Rule: A customer can purchase only a single time per month
        var baseDate = _clock.UtcNow.AddMonths(-1);
        var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
        if (ordersInThisMonth > 0)
            return false;

        //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
        var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
        if (haveBoughtBefore == 0 && purchaseValue > 100)
            return false;

        //Business Rule: A customer can purchases only during business hours and working days
        var now = _clock.UtcNow;
        if (now.Hour < 8 || now.Hour > 18 ||
            now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday)
            return false;

        return true;
    }
}
