namespace ASP.NET_Core_MVC.Models
{
    public class Item
    {
        #region Private properties
        private int _id;
        private string _name;
        private double _price;
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
        #endregion
    }
}
