namespace ASP.NET_Core_MVC.Models
{
    public class ItemClient
    {
        public int ItemId { get; set; }
        public Item Item { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
