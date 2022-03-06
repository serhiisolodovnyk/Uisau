using System.ComponentModel.DataAnnotations;

namespace Uisau.Models;

public class Car : BaseEntity
{
    public Guid Id { get; set; }
    
    [RegularExpression("[A-HJ-NPR-Z0-9]{13}[0-9]{4}", ErrorMessage = "Invalid Vehicle Identification Number Format.")]
    public string VinCode { get; set; }
    
    public Customer Customer { get; set; }
    
    public Guid CustomerId { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}