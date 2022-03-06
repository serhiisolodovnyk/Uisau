using Uisau.Models.Enums;

namespace Uisau.Models;

public class OrderItem : BaseEntity
{
    public Guid Id { get; set; }
    
    public TypeWork Type { get; set; }
    
    public float WorkingHours { get; set; }
    
    public string? Description { get; set; }
    
    public Order Order { get; set; }
    
    public Guid OrderId { get; set; }
}