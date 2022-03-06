namespace Uisau.Models;

public class Customer : BaseEntity
{
    public Guid Id { get; set; }
    
    public Account Account { get; set; }
    
    public Guid AccountId { get; set; }

    public ICollection<Car> Cars { get; set; } = new List<Car>();
}