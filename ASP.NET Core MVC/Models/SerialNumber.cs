using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_MVC.Models
{
    public class SerialNumber
    {
        private int _id;
        private string _name;
        private int? _itemId;
        private Item? _item;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public int? ItemId
        {
            get => _itemId;
            set => _itemId = value;
        }
        // Create a one to one relationship with the item and the serial number
        // using the ItemId as a foreign key
        [ForeignKey("ItemId")]
        public Item? Item
        {
            get => _item;
            set => _item = value;
        }
    }
}
