using System.Text.Json;
using Zuschnitt.Models;

namespace Zuschnitt;

public class AppState
{
    public Project Project { get; set; }

    public AppState()
    {
        Project = new Project();
    }
}