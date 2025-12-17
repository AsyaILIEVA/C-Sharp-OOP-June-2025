using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;


namespace BlackFriday.Models
{
    //The User is a base class of any type of user,
    //and it should not be able to be instantiated directly.
    public abstract class User : IUser
    {
        private string userName;
        private bool hasDataAccess;
        private string email;

//        Constructor
//A User should take the following values upon initialization: 
//string userName, string email, bool hasDataAccess
        protected User(string userName, string email, bool hasDataAccess)
        {
            UserName = userName;
            Email = email;
            HasDataAccess = hasDataAccess;
                
        }
        //        UserName - string
        //oIf the name is null or whitespace, throw a new ArgumentException with the message: 
        //"Username is required."
        public string UserName 
        {
            get 
            {               
                return userName;
            } 
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);
                }

                userName = value;
            }
        }

        //HasDataAcess – bool
//        oThis property indicates whether the user has access to data management features
//oIts behavior is determined by the specific child class: for Admin always returns true / for User always returns false
//oThe value is not directly set in the base class but is implemented differently in each child class.
        public bool HasDataAccess 
        { get 
            { return hasDataAccess; }
            private set { hasDataAccess = value; } 
        }


        //        Email – string
        //oIf HasDataAccess is true, no exception is thrown for a missing or invalid email.
        //In this case the property returns: "hidden"
        //If HasDataAccess is false, Email is validated properly.
        //If null or whitespace is passed, throw a new ArgumentException with the message: "Email is required."
        public string Email
        {            
           get 
                {
                    if (HasDataAccess)
                    {
                        return "hidden";
                    }

                    return email;
                }

            private set
            {
                if (!HasDataAccess && string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EmailRequired);
                }

                email = value;
            }
            
        }

//        Override ToString() method:
//Overrides the existing method ToString() and modifies it,
//so the returned string must be on a single line, in the following format:
//"{UserName} - Status: {"Client/Admin"(REFLECTION)},
//Contact Info: {email}"	
        public override string ToString()
        {
            string childClassName = this.GetType().Name;
            return $"{UserName} - Status: {childClassName}, Contact Info: {email}";
        }
    }
}
