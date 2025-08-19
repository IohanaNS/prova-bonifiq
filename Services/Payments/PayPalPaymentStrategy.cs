using ProvaPub.Services.enums;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services.Payments;

public class PayPalPaymentStrategy : IPaymentStrategy
{
    public PaymentType Type => PaymentType.Paypal;

    public Task Pay(decimal amount, int customerId)
    {
        return Task.CompletedTask;
    }
}
