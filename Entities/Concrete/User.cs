﻿using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete;

public class User:BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Rental>? RentalList { get; set; }
    
}