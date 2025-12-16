public class CarRoute : RouteBase
{
    private string _filename = "car_routes.csv";

    public void LoadRoutes()
    {
        LoadRoutesFromFile(_filename);
    }

    public void SaveRoute(int unitRoute, List<string> routeStops)
    {
        SaveRoute(unitRoute, routeStops, _filename);
    }

    

    // No UpdateRoute → updates not allowed for car routes
}