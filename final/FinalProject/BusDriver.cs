public class BusDriver : DriverBase
{
    public BusDriver() : base() { }

    public BusDriver(string name, string idNumber, string vehicleCapacity, int unitRoute, string userPassword)
        : base(name, idNumber, vehicleCapacity, unitRoute, userPassword)
    {
    }

    public override string GetDriverInfo()
    {
        return $"[BUS DRIVER]\n" + base.GetDriverInfo();
    }
}
