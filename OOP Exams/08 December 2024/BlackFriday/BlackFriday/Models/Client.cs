namespace BlackFriday.Models
{
    //Client
//    HasDataAccess property returns false
//Purchases – IReadOnlyDictionary<string, bool>
//Additional property holding:
//oKeys -  the names of all purchased products
//oValues – if the product is bought with a discount, set the value to true, otherwise - false
//The Constructor of the Client should take the following parameters upon initialization:
//string userName, string email
//Also initializes the Purchases collection
//Behavior
//void PurchaseProduct(string productName, bool blackFridayFlag)
//Adds the productName as a Key to the Purchases collection, with Value - blackFridayFlag
    internal class Client : User
    {
        private Dictionary<string, bool> purchases;
        public Client(string userName, string email) 
            : base(userName, email, false)
        {
            purchases = new Dictionary<string, bool>();
        }

        public IReadOnlyDictionary<string, bool> Purchases
        {
            get
            {
                return purchases;
            }
        }

        public void PurchasesProduct(string productName, bool blackFridayFlag)
        {
            purchases.Add(productName, blackFridayFlag);
            //purchases[productName] = blackFridayFlag;
        }
    }
}
