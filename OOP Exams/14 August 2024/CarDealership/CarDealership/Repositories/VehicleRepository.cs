using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> models;

        public VehicleRepository()
        {
            models = new List<IVehicle>();
        }
        public IReadOnlyCollection<IVehicle> Models => models.AsReadOnly();

        public void Add(IVehicle model)
        {
             models.Add(model);
        }

        public bool Exists(string model) 
            => models.Any(m => m.Model == model);

        public IVehicle Get(string model)        
           => models.FirstOrDefault(m => m.Model == model);        

        public bool Remove(string model)
        {
            //return models.Remove(Get(model));

            IVehicle vehicle = Get(model);

            if (vehicle != null) 
            {
                return false;
            }

            models.Remove(vehicle);

            return true;
        }
    }
}
