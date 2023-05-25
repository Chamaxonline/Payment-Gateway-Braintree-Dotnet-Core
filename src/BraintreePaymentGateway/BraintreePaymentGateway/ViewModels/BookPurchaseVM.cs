using BraintreePaymentGateway.Models;

namespace BraintreePaymentGateway.ViewModels
{
    public class BookPurchaseVM:Book
    {
        public string Nonce { get; set; }
    }
}
