using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;


namespace CarDealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private string model;
        private double price;
        private readonly List<string> buyers;

        protected Vehicle(string model, double price)
        {
            Model = model;
            Price = price;

            buyers = new List<string>();
        }
        public string Model 
        {
            get { return model; }

            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelIsRequired);
                }

                model = value; 
            }
        }
        public double Price
        {
            get { return price; }

            private set
            {
                if (price <= 0) //positive number >0
                {
                    throw new ArgumentException(ExceptionMessages.PriceMustBePositive);
                }

                price = value;
            }
        }   
        public int SalesCount => Buyers.Count;
        public IReadOnlyCollection<string> Buyers => buyers.AsReadOnly();
        
        public void SellVehicle(string buyerName)
        {
            buyers.Add(buyerName);
        }
        public override string ToString()
        {
            return $"{Model} - Price: {Price:F2}, Total Model Sales: {SalesCount}";
        }
    }
}
