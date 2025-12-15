public class BusDriver
{
    protected string _name;
    protected string _idNumber;
    protected string _vehicleCapacity;
    protected int _unitRoute;
    public string _userPassword;

    public BusDriver()
    {
    }

    public BusDriver(string name, string idNumber, string vehicleCapacity, int unitRoute, string userPassword)
    {
        _name = name;
        _idNumber = idNumber;
        _vehicleCapacity = vehicleCapacity;
        _unitRoute = unitRoute;
        _userPassword = userPassword;
    }

    public string GetDriverInfo()
    {
        return $"Name: {_name}\nID: {_idNumber}\nCapacity: {_vehicleCapacity}\nRoute: {_unitRoute}";
    }       

    public string StringFormat()
    {
        return $"{_name},{_idNumber},{_vehicleCapacity},{_unitRoute},{_userPassword}";
    }

    public bool ValidatePassword(string password)
    {
        return _userPassword == password;
    }

}