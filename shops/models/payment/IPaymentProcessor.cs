namespace Shops.Models.Payment
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
        bool RefundPayment(decimal amount);
    }
}