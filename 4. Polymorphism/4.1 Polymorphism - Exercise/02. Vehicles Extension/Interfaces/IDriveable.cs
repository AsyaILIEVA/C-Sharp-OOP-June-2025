namespace Vehicles.Interfaces
{
    public interface IDriveable
    {
        public void Drive(double distance);
        public void DriveEmpty(double distance);
        public void Refuel(double quantity);
    }
}