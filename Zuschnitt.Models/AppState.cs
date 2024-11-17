using System.Text.Json;

namespace Zuschnitt.Models;

public class AppState
{
    public Project Project { get; set; }
    public event Action? OnStateChange;

    public AppState()
    {
        Project = new Project();
    }

    public void StateHasChanged() => OnStateChange?.Invoke();
}