using CarDealership.Models.Contracts;
using CarDealership.Utilities.Messages;

namespace CarDealership.Models
{
    public abstract class Customer : ICustomer
    {
        private string name;
        private readonly List<string> purchases;

        protected Customer(string name)
        {
            Name = name;

            purchases = new List<string>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameIsRequired);
                }

                name = value;
            }
        }

        public IReadOnlyCollection<string> Purchases => purchases.AsReadOnly();

        public void BuyVehicle(string vehicleModel)
        {
            purchases.Add(vehicleModel);
        }

        public override string ToString()
        {
            return $"{Name} - Purchases: {Purchases.Count}";
        }
    }
}
