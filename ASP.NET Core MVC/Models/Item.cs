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
        #endregion
    }
}
