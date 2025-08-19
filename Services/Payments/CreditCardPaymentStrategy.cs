using ProvaPub.Services.enums;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services.Payments;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public PaymentType Type => PaymentType.CreditCard;

    public Task Pay(decimal amount, int customerId)
    {
        return Task.CompletedTask;
    }
}
