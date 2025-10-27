namespace WildFarm.Exceptions
{
    public class InvalidFoodTypeException : Exception
    {
        private const string DefaultMessage = "Invalid food type!";

        public InvalidFoodTypeException()
            : base(DefaultMessage)
        {

        }

        public InvalidFoodTypeException(string message)
            : base(message)
        {

        }
    }
}
