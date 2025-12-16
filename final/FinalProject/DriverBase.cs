public abstract class DriverBase
{
    protected string _name;
    protected string _idNumber;
    protected string _vehicleCapacity;
    protected int _unitRoute;
    protected string _userPassword;

    protected DriverBase() { }

    public int UnitRoute
    {
        get { return _unitRoute; }
    }

    protected DriverBase(string name, string idNumber, string vehicleCapacity, int unitRoute, string userPassword)
    {
        _name = name;
        _idNumber = idNumber;
        _vehicleCapacity = vehicleCapacity;
        _unitRoute = unitRoute;
        _userPassword = userPassword;
    }

    public virtual string GetDriverInfo()
    {
        return $"Name: {_name}\nID: {_idNumber}\nCapacity: {_vehicleCapacity}\nRoute: {_unitRoute}";
    }

    public virtual string StringFormat()
    {
        return $"{_name},{_idNumber},{_vehicleCapacity},{_unitRoute},{_userPassword}";
    }

    public bool ValidatePassword(string password)
    {
        return _userPassword == password;
    }
}