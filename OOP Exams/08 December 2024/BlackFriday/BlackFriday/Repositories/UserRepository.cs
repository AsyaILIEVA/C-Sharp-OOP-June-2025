using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;


namespace BlackFriday.Repositories
{
    //The UserRepository is an IRepository<IUser>.
    //Collection of all existing users in the application.
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> models;
        public UserRepository()
        {
            models = new List<IUser>();
        }

        //Models – a collection of users(unmodifiable)
        public IReadOnlyCollection<IUser> Models => models.AsReadOnly();

//        void AddNew(IUser user)
//Adds a user to the repository.
        public void AddNew(IUser model)
        {
            models.Add(model);
        }

        //bool Exists(string name)
//Returns true if a user with a userName matching the given parameter exists in the repository,
//otherwise returns false.
        public bool Exists(string name)
        {
            return models.Any(u => u.UserName == name);
        }

//        IUser GetByName(string name)
//Returns a user with a userName value, equal to the given parameter.
//No such user -  returns null.
        public IUser GetByName(string name)
        {
            return models.FirstOrDefault(u => u.UserName == name);
                
        }

        
    }
}

