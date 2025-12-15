using Microsoft.VisualBasic;

public class BusRoute
{
    private Dictionary<int, List<string>> _routeStops = new();

    public List<string> indexesToRoute(string routeData)
    {
        //Converts route indexes to a actual destination names.
        List<string> destinationsList = new List<string>();
        Destinations destinations = new Destinations();
        List<string> allDestinations = destinations.GetDestinations();
        var stops = routeData.Split(',');
        foreach (string stop in stops)
        {
            destinationsList.Add(allDestinations[int.Parse(stop) - 1]);
        }
        return destinationsList;
    }

    public List<string> GetCurrentRouteStops(int unitNumber)
    {
        if (_routeStops.ContainsKey(unitNumber))
        {
            return _routeStops[unitNumber];
        }
        return new List<string>();
    }

    public void SaveRoutes(int unitNumber, List<string> routeDataList)
    {
        string filename = "routes.csv";

        // convert list to comma-separated string
        string routeData = string.Join(",", routeDataList);

        string routeInformation = $"{unitNumber};{routeData}";
        File.AppendAllText(filename, routeInformation + Environment.NewLine);
    }

    public void LoadRoutes()
    {
    string filename = "routes.csv";

    if (!File.Exists(filename))
        return;

    var lines = File.ReadAllLines(filename);

    _routeStops.Clear();

    foreach (var line in lines)
        {
        // Saltar líneas vacías
        if (string.IsNullOrWhiteSpace(line))
            continue;

        var parts = line.Split(';');

        // Debe haber al menos 2 partes: número de ruta y paradas
        if (parts.Length < 2)
            continue;

        // Validar que el número de ruta sea válido
        if (!int.TryParse(parts[0], out int unitNumber))
            continue;

        // Validar que existan paradas
        if (string.IsNullOrWhiteSpace(parts[1]))
            continue;

        var stops = parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => s.Trim())
                            .ToList();

        _routeStops[unitNumber] = stops;
        }
    }

    public void UpdateRoute(int unitNumber, List<string> newRouteStops)
    {
        string filename = "routes.csv";

        // Read all lines from the file
        var lines = File.ReadAllLines(filename).ToList();
        // Create the new line with updated route data
        string routeData = string.Join(",", newRouteStops);
        string newLine = $"{unitNumber};{routeData}";

        // Find and update the line for the given unit number
        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith(unitNumber + ";"))
            {
                // Update the line
                lines[i] = newLine;
                break;
            }
        }
        
        // Write all lines back to the file
        File.WriteAllLines(filename, lines);
    }

}