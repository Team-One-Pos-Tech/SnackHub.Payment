using SnackHub.Payment.Application.ViewModel.Customer;
using SnackHub.Payment.Domain.Enums;

namespace SnackHub.Payment.Application.ViewModel.Payment
{
    public class PaymentVM
    {
        public Gateway Gatway { get; set; }
        public string? GatewayRefID { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateApproved { get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public CustomerVM Customer { get; set; }
    }
}
