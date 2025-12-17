using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;


namespace BlackFriday.Repositories
{
    //The ProductRepository is an IRepository<IProduct>.
    //Collection of all existing products in the application.
    public class ProductRepository : IRepository<IProduct>
    {

        private List<IProduct> models;

        public ProductRepository()
        {
            models = new List<IProduct>();
        }

       // Models – a collection of products(unmodifiable)
        public IReadOnlyCollection<IProduct> Models => models.AsReadOnly();

        //void AddNew(IProduct product)
        //Adds a product to the repository.
        public void AddNew(IProduct model)
        {
            models.Add(model);
        }

        //bool Exists(string name)
        //Returns true if a product with a productName matching the given parameter exists in the repository,
        //otherwise returns false.
        public bool Exists(string name)
        {
           return models.Any(p => p.ProductName == name);
        }

        //        IProduct GetByName(string name)
        //Returns a product with a productName value, equal to the given parameter.
        //If no such product is found in the repository returns null.
        public IProduct GetByName(string name)
        {
            return models.FirstOrDefault(p => p.ProductName == name);
        }

    }
}
