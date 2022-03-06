namespace Uisau.Models;

public class Order : BaseEntity
{
    public Guid Id { get; set; }
    
    public Car Car { get; set; }
    
    public Guid CarId { get; set; }
    
    public RepairShop RepairShop { get; set; }
    
    public Guid RepairShopId { get; set; }
    
    public DateTime StartTime { get; set; }

    public string? Description { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
}