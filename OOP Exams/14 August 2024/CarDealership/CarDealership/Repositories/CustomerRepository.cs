using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private readonly List<ICustomer> models;
        public CustomerRepository()
        {
            models = new List<ICustomer>();
        }
        public IReadOnlyCollection<ICustomer> Models => models.AsReadOnly();

        public void Add(ICustomer model) => models.Add(model);

        public bool Exists(string model)
          => models.Any(m => m.Name == model);

        public ICustomer Get(string model)
          => models.FirstOrDefault(m => m.Name == model);

        public bool Remove(string model)
        {
            return models.Remove(Get(model));
        }
    }
}
