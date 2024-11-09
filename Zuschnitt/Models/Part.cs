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
    public bool Highlighted { get; set; }

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
    
    public Part(Part part)
    {
        Id = Guid.NewGuid();
        Name = $"{part.Name} copy";
        Width = part.Width;
        Height = part.Height;
        Color = part.Color;
        FillColor = part.FillColor;
        Highlighted = false;
    }

    public double FillOpacity()
    {
        if (Highlighted) return 0.5;
        return 0.1;
    }
}
