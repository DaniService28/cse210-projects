public class BusRoute : RouteBase
{
    private string _filename = "routes.csv";

    public void LoadRoutes()
    {
        LoadRoutesFromFile(_filename);
    }

    public void SaveRoutes(int unitNumber, List<string> routeDataList)
    {
        SaveRoute(unitNumber, routeDataList, _filename);
    }

    public void UpdateRoute(int unitNumber, List<string> newRouteStops)
    {
        UpdateRouteInFile(unitNumber, newRouteStops, _filename);
    }

    
}