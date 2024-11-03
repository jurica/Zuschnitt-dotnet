using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components;

namespace Zuschnitt.Models;

public class Part
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Color { get; set; }
    public string FillColor { get; set; }
    [JsonIgnore]
    public bool Highlighted { get; set; }
    [JsonIgnore]
    public bool Editing { get; set; }

    public Part()
    {
        Id = Guid.NewGuid();
        Name = "";
        Width = 50;
        Height = 50;
        Color = "black";
        FillColor = "green";
        Highlighted = false;
    }

    public double FillOpacity()
    {
        if (Highlighted) return 0.5;
        return 0.1;
    }
    
    public EventCallback OnChange { get; set; }
}
