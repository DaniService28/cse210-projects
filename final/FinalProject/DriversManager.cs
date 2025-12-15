public class DriversManager
{
    protected Dictionary<string, BusDriver> _drivers = new();

    public bool ValidateUnitNumber(string unitNumber)
    {
        return _drivers.ContainsKey(unitNumber);
    }

    public void SaveDriver(string licenseDriver, BusDriver driver)
    {
        string filename = "drivers.csv";
        string driverInformation = $"{licenseDriver},{driver.StringFormat()}";
        File.AppendAllText(filename, driverInformation + Environment.NewLine);
        _drivers[licenseDriver] = driver;
    }

    public void LoadDrivers()
    {
        string filename = "drivers.csv";

        if (!File.Exists(filename))
            return;

        var lines = File.ReadAllLines(filename);

        for (int i = 1; i < lines.Length; i++)
        {
            var line = lines[i];
            var parts = line.Split(',');

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

    public BusDriver GetDriver(string unitNumber)
    {
        _drivers.TryGetValue(unitNumber, out var driver);
        return driver;
    }

}