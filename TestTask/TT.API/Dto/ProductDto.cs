﻿namespace TT.API.Dto;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
}