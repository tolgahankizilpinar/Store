﻿using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Product
    {
        public int ProductId { get; set; }     
        public string? ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Summary { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public bool ShowCase { get; set; }  

        
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

