using ProvaPub.Services.enums;
using ProvaPub.Services.Interfaces;

namespace ProvaPub.Services.Payments;

public class PixPaymentStrategy : IPaymentStrategy
{
    public PaymentType Type => PaymentType.Pix;

    public Task Pay(decimal amount, int customerId)
    {
        return Task.CompletedTask;
    }
}
