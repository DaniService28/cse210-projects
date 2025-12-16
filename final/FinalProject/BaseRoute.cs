public abstract class RouteBase
{
    protected Dictionary<int, List<string>> _routeStops = new();

    public IReadOnlyDictionary<int, List<string>> GetAllRoutes()
    {
        return _routeStops;
    }

    public List<string> GetCurrentRouteStops(int unitNumber)
    {
        return _routeStops.ContainsKey(unitNumber)
            ? _routeStops[unitNumber]
            : new List<string>();
    }

    public void SaveRoute(int unitNumber, List<string> routeDataList, string filename)
    {
        string routeData = string.Join(",", routeDataList);
        string routeInformation = $"{unitNumber};{routeData}";
        File.AppendAllText(filename, routeInformation + Environment.NewLine);
    }

    public void LoadRoutesFromFile(string filename)
    {
        if (!File.Exists(filename))
            return;

        var lines = File.ReadAllLines(filename);
        _routeStops.Clear();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(';');
            if (parts.Length < 2) continue;
            if (!int.TryParse(parts[0], out int unitNumber)) continue;
            if (string.IsNullOrWhiteSpace(parts[1])) continue;

            var stops = parts[1]
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();

            _routeStops[unitNumber] = stops;
        }
    }

    public void UpdateRouteInFile(int unitNumber, List<string> newRouteStops, string filename)
    {
        var lines = File.ReadAllLines(filename).ToList();
        string routeData = string.Join(",", newRouteStops);
        string newLine = $"{unitNumber};{routeData}";

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith(unitNumber + ";"))
            {
                lines[i] = newLine;
                break;
            }
        }

        File.WriteAllLines(filename, lines);
    }
}