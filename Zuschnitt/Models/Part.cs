using System.Text.Json.Serialization;

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
    public bool Hightlighted { get; set; }
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
        Hightlighted = false;
    }

    public double FillOpacity()
    {
        if (Hightlighted) return 0.5;
        return 0.01;
    }
}
