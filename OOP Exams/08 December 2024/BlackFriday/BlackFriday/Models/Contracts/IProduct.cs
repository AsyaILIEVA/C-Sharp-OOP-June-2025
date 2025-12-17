namespace BlackFriday.Models.Contracts
{
    //C# OOP Regular Exam – 08 Dec 2024 - 01. Black Friday
    public interface IProduct
    {
        //if we have only getter, that means private set

        string ProductName { get; }

        double BasePrice { get; }

        double BlackFridayPrice { get; }

        bool IsSold { get; }

        void UpdatePrice(double newPriceValue);

        void ToggleStatus();
    }
}
