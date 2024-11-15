namespace SnackHub.Payment.Domain.Entities;

public class Entity<TPK> where TPK : IComparable
{
    public TPK Id { get; private set; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateLastUpdated { get; set; }
}