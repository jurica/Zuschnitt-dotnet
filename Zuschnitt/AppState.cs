using System.Text.Json;
using Zuschnitt.Models;

namespace Zuschnitt;

public class AppState
{
    public Project Project { get; private set; }

    public AppState()
    {
        Project = new Project();
    }

    public string Serialize()
    {
        return JsonSerializer.Serialize(Project);
    }

    public void Deserialize(string data)
    {
        var p = JsonSerializer.Deserialize<Project>(data);
        if (p != null)
        {
            Project = p;
        }
    }
}