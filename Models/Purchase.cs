﻿namespace Shop.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public List<PurchaseItem> Items { get; set; } = new();
    }
}
