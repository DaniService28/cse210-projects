public class CarDriver : DriverBase
{
    public DateTime RideDate;
    public decimal MinimumPrice;

    public CarDriver() : base() { }

    public CarDriver(
        string name,
        string idNumber,
        string vehicleCapacity,
        int unitRoute,
        string userPassword,
        DateTime rideDate,
        decimal minimumPrice)
        : base(name, idNumber, vehicleCapacity, unitRoute, userPassword)
    {
        RideDate = rideDate;
        MinimumPrice = minimumPrice;
    }

    public override string StringFormat()
    {
        return $"{_name},{_idNumber},{_vehicleCapacity},{_unitRoute},{_userPassword},{RideDate:yyyy-MM-dd},{MinimumPrice}";
    }

    public bool IsRideAvailable()
    {
        return RideDate.Date >= DateTime.Now.Date;
    }

    public override string GetDriverInfo()
    {
        return $"Name: {_name}\n" +
            $"Capacity: {_vehicleCapacity}\n" +
            $"Ride Date: {RideDate:yyyy-MM-dd}\n" +
            $"Minimum Price: ${MinimumPrice}";
    }

    public List<string> GetCurrentRouteStops(int unitNumber)
    {
        string filename = "car_routes.csv";

        if (!File.Exists(filename))
            return new List<string>();

        var lines = File.ReadAllLines(filename);

        foreach (var line in lines.Skip(1))
        {
            var parts = line.Split(',');

            if (parts[0] == unitNumber.ToString())
            {
                return parts.Skip(1).ToList(); 
            }
        }

        return new List<string>();
    }

}