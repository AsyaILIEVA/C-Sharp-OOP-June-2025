namespace BlackFriday.Models
{
    //Child Classes
    //Service
//    Overrides the BlackFridayPrice property to return a value
//    with a 20% discount on the BasePrice
//The Constructor of the Service should take the following parameters upon initialization:
//string productName, double basePrice
    public class Service : Product
    {
        public Service(string productName, double basePrice) 
            : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice 
        { 
            get { return base.BasePrice * 0.8; } 
        }
    }
}
