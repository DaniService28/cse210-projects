public class Destinations
{
    private List<string> _cityAreas = new List<string>()
    {
    "Alborada",
    "Samanes",
    "Garzota",
    "Los Ceibos",
    "Urdesa Norte",
    "Sauces",
    "Kennedy Norte",
    "Bellavista",
    "Puerto Azul",
    "Guasmo Este",
    "Guasmo Oeste",
    "Isla Trinitaria",
    "Batallón del Suburbio",
    "Floresta",
    "La Pradera",
    "Centenario",
    "Huancavilca",
    "9 de Octubre",
    "Las Peñas",
    "Malecón 2000",
    "Ayacucho",
    "Miraflores",
    "Letamendi",
    "Rocafuerte",
    "Bolívar",
    "Sucre",
    "Lomas de Prosperina",
    "Monte Bello",
    "Ciudadela Ferroviaria",
    "Bosques del Salado"
    };

    public void AddDestination(string newDestination)
    {
        _cityAreas.Add(newDestination);
    }

    public void DisplayAllDestinations()
    {
        for (int i = 0; i < _cityAreas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_cityAreas[i]}");
        }

    }

    public List<string> GetDestinations()
    {
        return _cityAreas;
    }

    public List<string> indexesToRoute(string routeData)
    {
        List<string> allDestinations = GetDestinations();

        return routeData
            .Split(',')
            .Select(i => allDestinations[int.Parse(i) - 1])
            .ToList();
    }

}