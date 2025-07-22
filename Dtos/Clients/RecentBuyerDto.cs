namespace Shop.Dtos.Clients
{
    public class RecentBuyerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public DateTime LastPurchaseDate { get; set; }
    }
}
