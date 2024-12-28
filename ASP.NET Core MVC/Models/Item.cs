using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NET_Core_MVC.Models
{
    public class Item
    {
        #region Private properties
        private int _id;
        private string _name;
        private double _price;
        private int? _serialNumberId;
        private SerialNumber? _serialNumber;
        private int? _categoryId;
        private Category? _category;
        #endregion

        #region Getters and Setters
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
        public double Price
        {
            get => _price;
            set => _price = value;
        }

        public int? SerialNumberId
        {
            get => _serialNumberId;
            set => _serialNumberId = value;
        }

        public SerialNumber? SerialNumber
        {
            get => _serialNumber;
            set => _serialNumber = value;
        }

        public int? CategoryId
        {
            get => _categoryId;
            set => _categoryId = value;
        }

        // Connect the Item with the Category using the CategoryId as a foreign key
        [ForeignKey("CategoryId")]
        public Category? Category
        {
            get => _category;
            set => _category = value;
        }

        public List<ItemClient>? ItemClients { get; set; }
        #endregion
    }
}
