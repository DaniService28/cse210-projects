using System.Globalization;

public class DriversManager
{
    protected Dictionary<string, DriverBase> _drivers = new();

    public void SaveDriver(string unitNumber, DriverBase driver, string filename)
    {
        string driverInformation = $"{unitNumber},{driver.StringFormat()}";
        File.AppendAllText(filename, driverInformation + Environment.NewLine);
        _drivers[unitNumber] = driver;
    }

    public DriverBase GetDriver(string unitNumber)
    {
        _drivers.TryGetValue(unitNumber, out var driver);
        return driver;
    }

    public bool ValidateUnitNumber(string unitNumber)
    {
        return _drivers.ContainsKey(unitNumber);
    }

    public void LoadBusDrivers()
    {
        string filename = "drivers.csv";

        if (!File.Exists(filename))
            return;

        var lines = File.ReadAllLines(filename);

        // Si tu CSV tiene encabezado, empezamos en 1
        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');

            if (parts.Length < 6)
                continue; // línea corrupta

            string unitNumber = parts[0];
            string name = parts[1];
            string idNumber = parts[2];
            string vehicleCapacity = parts[3];
            int unitRoute = int.Parse(parts[4]);
            string userPassword = parts[5];

            BusDriver driver = new BusDriver(
                name,
                idNumber,
                vehicleCapacity,
                unitRoute,
                userPassword
            );

            _drivers[unitNumber] = driver;
        }
    }

    public void LoadCarDrivers()
    {
        string filename = "car_drivers.csv";

        if (!File.Exists(filename))
            return;

        var lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++)
        {
            var parts = lines[i].Split(',');

            if (parts.Length < 8)
                continue;

            string unitNumber = parts[0];
            string name = parts[1];
            string idNumber = parts[2];
            string vehicleCapacity = parts[3];
            int unitRoute = int.Parse(parts[4]);
            string userPassword = parts[5];
            DateTime rideDate = DateTime.Parse(parts[6]);
            decimal minPrice = decimal.Parse(parts[7], CultureInfo.InvariantCulture);

            CarDriver driver = new CarDriver(
                name,
                idNumber,
                vehicleCapacity,
                unitRoute,
                userPassword,
                rideDate,
                minPrice
            );

            _drivers[unitNumber] = driver;
        }
    }

    public List<CarDriver> GetAllCarDrivers()
    {
        return _drivers.Values.OfType<CarDriver>().ToList();
    }

}