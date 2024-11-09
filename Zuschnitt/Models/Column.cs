using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Column 
{
    public Guid Id { get; set; }
    public string Color { get; set; }
    public string FillColor { get; set; }
    public List<Part> Parts { get; set; }
    [JsonIgnore]
    public bool Highlighted { get; set; }

    public Column()
    {
        Id = Guid.NewGuid();
        Color = "black";
        FillColor = "purple";
        Parts = new ();
    }
    
    public Column(Column column)
    {
        Id = Guid.NewGuid();
        Color = column.Color;
        FillColor = column.FillColor;
        Parts = new ();
        column.Parts.ForEach(p => Parts.Add(new Part(p)));
    }

    public int Height()
    {
        int result = 0;
        if (Parts.Any()) result = Parts.Sum(p => p.Height);
        return result;
    }

    public int Width()
    {
        int result = 0;
        if (Parts.Any()) result = Parts.Max(p => p.Width);
        return result;
    }

    public void Reassign(Sheet currentSheet, Sheet newSheet)
    {
        currentSheet.Columns.Remove(this);
        newSheet.Columns.Add(this);
    }
    
    public double FillOpacity()
    {
        if (Highlighted) return 0.5;
        return 0.1;
    }
}
