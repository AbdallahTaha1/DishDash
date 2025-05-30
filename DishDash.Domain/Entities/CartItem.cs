﻿using System.ComponentModel.DataAnnotations;

namespace DishDash.Domain.Entities
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue)]
        public double UnitPrice { get; set; }

        [Range(0, double.MaxValue)]
        public double TotalPrice { get; set; }

        public int CartId { get; set; }

        [Required]
        public Cart Cart { get; set; } = default!;

        public int MenuItemId { get; set; }

        [Required]
        public MenuItem MenuItem { get; set; } = default!;
    }
}

