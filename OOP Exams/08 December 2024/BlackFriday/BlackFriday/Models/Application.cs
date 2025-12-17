using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;


namespace BlackFriday.Models
{
    public class Application : IApplication
    {
        //Products – IRepository<IProduct> 
       // Users – IRepository<IUser>
        private IRepository<IProduct> products;
        private IRepository<IUser> users;

       // An Application should take no values upon initialization
       // and should initialize new instances of the Products and Users collections.
        public Application()
        {
            products = new ProductRepository();
            users = new UserRepository();
        }
        public IRepository<IProduct> Products {get {return products;}}
        //public IRepository<IProduct> Products => products;

        public IRepository<IUser> Users {get {return users;}}
    }
}
