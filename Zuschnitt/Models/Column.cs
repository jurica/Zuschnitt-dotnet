using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Column 
{
    public Guid Id { get; set; }
    public string Color { get; set; }
    public string FillColor { get; set; }
    public List<Part> Parts { get; set; }
    [JsonIgnore]
    public bool Hightlighted { get; set; }
    [JsonIgnore]
    public bool Editing { get; set; }

    public Column()
    {
        Id = Guid.NewGuid();
        Color = "black";
        FillColor = "purple";
        Parts = new ();
    }

    public int Height()
    {
        if (Parts.Count() == 0) return 0;
        return Parts.Sum(p => p.Height);
    }

    public int Width()
    {
        if (Parts.Count() == 0) return 0;
        return Parts.Max(p => p.Width);
    }

    public void Reassign(Sheet currentSheet, Sheet newSheet)
    {
        currentSheet.Columns.Remove(this);
        newSheet.Columns.Add(this);
    }
    
    public double FillOpacity()
    {
        if (Hightlighted) return 0.5;
        return 0.01;
    }
}
