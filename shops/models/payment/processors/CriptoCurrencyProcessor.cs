namespace Shops.Models.Payment.Processors
{
    public class CryptoCurrencyProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            return true;
        }

        public bool RefundPayment(decimal amount)
        {
            return true;
        }
    }
}