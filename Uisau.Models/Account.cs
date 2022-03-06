﻿using Uisau.Models.Enums;

namespace Uisau.Models;

public class Account : BaseEntity
{
    public Guid Id { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
    
    public AccountType AccountType { get; set; }
}
