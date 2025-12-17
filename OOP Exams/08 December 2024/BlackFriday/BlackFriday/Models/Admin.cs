namespace BlackFriday.Models
{
//    Admin
//HasDataAccess property returns true
//The Constructor of the Admin should take the following parameters upon initialization:
//string userName, string email
    public class Admin : User
    {
        public Admin(string userName, string email) 
            : base(userName, email, true)
        {
        }
    }
}
