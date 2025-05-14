namespace Shops.Models.Payment.Processors
{
    public class CreditCardProcessor : IPaymentProcessor, IPaymentValidator
    {
        public bool ValidatePayment()
        {
            return true;
        }

        public bool ProcessPayment(decimal amount)
        {
            if (!ValidatePayment()) return false;
            return true;
        }

        public bool RefundPayment(decimal amount)
        {
            return true;
        }
    }
}