using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;


namespace BlackFriday.Models
{
    //The Product is a base class of any type of product,
    //and it should not be able to be instantiated directly. - this means:
    // class should be ABSTRACT.
    public abstract class Product : IProduct
    {
        //private fields
        private string productName;
        private double basePrice;
        private double blackFridayPrice;
        private bool isSold;

//        Constructor:
//A Product should take the following values upon initialization: 
//string productName, double basePrice
//The constructor validates and sets the ProductName and BasePrice properties.
//Initializes the IsSold property to false
        public Product(string productName, double basePrice) 
        {
            ProductName = productName;
            BasePrice = basePrice;
            IsSold = false;
            
        }


        //ProductName - string
       //o Must NOT be null or whitespace.
       //If invalid throw a new ArgumentException with the message: 
       //"Product name is required."
        public string ProductName 
        {
            get { return productName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ProductNameRequired);
                    //ExceptionMessages is Folder in Messages - Utilities
                    //Use Ctrl . to implement ProductNameRequired
                }

                productName = value;
            }
        }

        //BasePrice – double
        //Must be a positive number.
        //If invalid, throw a new ArgumentException with the message: 
        //"Price cannot be zero or negative."
        public double BasePrice        
        {
            get { return basePrice; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
                }

                basePrice = value;
            }
        }

        //BlackFridayPrice – double
        //oA virtual property, overridden in child classes to calculate the discounted price.
        public virtual double BlackFridayPrice
        {
            get { return blackFridayPrice; }
            private set { blackFridayPrice = value; }
        }

        //IsSold – bool
        //oIndicates whether the product has been sold.Set to false as default.
        public bool IsSold
        {
            get { return IsSold; }
            private set
            {
                this.isSold = value;
            }
        }

//        Override ToString() method:
//Overrides the existing method ToString() and modify it,
//so the returned string must be on a single line, in the following format:
//"Product: {ProductName}, Price: {BasePrice:F2}, You Save:
//{(BasePrice-BlackFridayPrice):F2}"

        //if have more than one line, we should use StringBuilder class
        public override string ToString()
        {
            return $"Product: {ProductName}, Price: {BasePrice:F2}, You Save: {(BasePrice-BlackFridayPrice):F2}";
        }

//        Behavior:

//void UpdatePrice(double newPriceValue)
//Updates the product's base price with a new value.

//void ToggleStatus()
//Marks the IsSold property to true if it is marked as false
//OR to false if it is marked as true.
        
        public void UpdatePrice(double newPriceValue)
        {
            BasePrice = newPriceValue;
        }

        public void ToggleStatus()
        {
            isSold = !isSold;
        }
    }
}
