public class RouteService
{
    private readonly BorderData borderData;

    public RouteService(BorderData borderData)
    {
        this.borderData = borderData;
    }

    public string[] FindRoute(string destination)
    {
        Queue<string> queue = new Queue<string>();
        HashSet<string> visited = new HashSet<string>();
        Dictionary<string, string> parent = new Dictionary<string, string>();

        queue.Enqueue("USA");
        visited.Add("USA");

        while (queue.Count > 0)
        {
            string current = queue.Dequeue();

            if (current == destination)
            {
                break;
            }

            foreach (string neighbor in borderData.GetBorders(current))
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    parent[neighbor] = current;
                    queue.Enqueue(neighbor);
                }
            }

        }

        List<string> route = new List<string>();

        string country = destination;

        while (country != "USA")
        {
            route.Add(country);
            country = parent[country];
        }

        route.Add("USA");
        route.Reverse();

        return route.ToArray();
    }

    public bool IsValidDestination(string destination)
    {
        return borderData.ContainsCountry(destination);
    }
}