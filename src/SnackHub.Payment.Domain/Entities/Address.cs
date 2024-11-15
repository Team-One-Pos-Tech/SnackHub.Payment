using SnackHub.Payment.Domain.Interface;

namespace SnackHub.Payment.Domain.Entities
{
    public class Address : Entity<Guid>, IAggregateRoot
    {
        public required string StreetName { get; set; }
        public int? StreetNumer { get; set; }
        public string? ZipCode { get; set; }
        public Guid CustomerID { get; set; }
        public Customer? Customer { get; set; }
    }
}
