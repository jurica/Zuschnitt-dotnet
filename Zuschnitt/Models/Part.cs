namespace Zuschnitt.Models;

public class Part
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string Color { get; set; }
    public string FillColor { get; set; }

    public Part()
    {
        Id = Guid.NewGuid();
        Name = "";
        Width = 50;
        Height = 50;
        Color = "black";
        FillColor = "none";
    }
}
