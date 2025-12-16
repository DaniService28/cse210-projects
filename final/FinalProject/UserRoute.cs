public class UserRoute
{
    // This class can be expanded with methods to find routes, etc.
    // For now, it just holds the routes data. in ReadOnlyDictionary<int, List<string>> _routeStops;
    private IReadOnlyDictionary<int, List<string>> _userRoutes;
    public UserRoute(IReadOnlyDictionary<int, List<string>> routes)
    {
        _userRoutes = routes;
    }

    public List<int> FindRoutesByDestination(string destination)
    {
        List<int> matchingRoutes = new();

        foreach (var kvp in _userRoutes)
        {
            // Case-insensitive comparison for destination matching
            // This checks if any stop in the route matches the destination ignoring case
            if (kvp.Value.Any(stop =>
                stop.Equals(destination, StringComparison.OrdinalIgnoreCase)))
                {
                    // Add the unit number to the list of matching routes
                    matchingRoutes.Add(kvp.Key);
                }
        }

        return matchingRoutes;
    }

    public List<int> FindDirectRoute(string origin, string destination)
    {
        var originRoutes = FindRoutesByDestination(origin);
        var destinationRoutes = FindRoutesByDestination(destination);

        // Find routes that both start and end at the specified locations
        return originRoutes
            .Intersect(destinationRoutes).ToList();
    }   

    public List<(int route1, string transferStop, int route2)>
    FindAllTransferRoutes(string origin, string destination)
    {
        // Find all routes that require a transfer between two routes
        var results = new List<(int, string, int)>();

        var originRoutes = FindRoutesByDestination(origin);
        var destinationRoutes = FindRoutesByDestination(destination);

        foreach (var r1 in originRoutes)
        {
            var stops1 = _userRoutes[r1];

            foreach (var r2 in destinationRoutes)
            {
                //Skip same route transfers
                if (r1 == r2)
                    continue;

                var stops2 = _userRoutes[r2];

                // Find common stops between the two routes
                var commonStops = stops1
                    .Intersect(stops2, StringComparer.OrdinalIgnoreCase);

                foreach (var stop in commonStops)
                {
                    //No allow transfer at origin
                    if (stop.Equals(origin, StringComparison.OrdinalIgnoreCase))
                        continue;

                    //No allow transfer at destination
                    if (stop.Equals(destination, StringComparison.OrdinalIgnoreCase))
                        continue;

                    results.Add((r1, stop, r2));
                }
            }
        }

        return results;
    }

    public List<string> FindAllRoutes(string origin, string destination)
    {
        List<string> options = new();

        //All direct routes
        var directRoutes = FindDirectRoute(origin, destination);
        foreach (var route in directRoutes)
        {
            options.Add($"Direct route: Take route {route} from {origin} to {destination}.");
        }

        //All transfer routes
        var transfers = FindAllTransferRoutes(origin, destination);
        foreach (var t in transfers)
        {
            options.Add($"Transfer route: Take route {t.route1} from {origin} to {t.transferStop}, " +
                        $"then change to route {t.route2} to reach {destination}.");
        }

        // If no routes found, indicate that
        if (options.Count == 0)
        {
            options.Add("No route found between those destinations.");
        }

        return options;
    }
}