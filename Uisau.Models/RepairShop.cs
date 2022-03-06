namespace Uisau.Models;

public class RepairShop : BaseEntity
{
    public string Address { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}