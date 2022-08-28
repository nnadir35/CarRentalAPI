﻿using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;

namespace Entities.Concrete;

public class Car:BaseEntity
{
    [ForeignKey("Id")]
    public int Id { get; set; }
    public int BrandId { get; set; }
    public int ColorId { get; set; }
    public string Description { get; set; }
    public int ModelYear { get; set; }
    public float DailyPrice { get; set; }
}