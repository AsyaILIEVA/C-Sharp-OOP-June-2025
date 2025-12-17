namespace BlackFriday.Models
{
    //Item
//    Overrides the BlackFridayPrice property to return a value
//    with a 30% discount on the BasePrice
//The Constructor of the Item should take the following parameters upon initialization:
//string productName, double basePrice
    public class Item : Product
    {
        public Item(string productName, double basePrice) 
            : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice
        {
            get { return base.BasePrice * 0.7; }
        }
    }
}
