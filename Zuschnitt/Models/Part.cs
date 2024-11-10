using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Part
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public bool Done { get; set; }
    public Column Parent { get; private set; }
    [JsonIgnore] public bool Highlighted { get; set; }

    public Part(Column parent)
    {
        Id = Guid.NewGuid();
        Name = "";
        Width = 50;
        Height = 50;
        Highlighted = false;
        Done = false;
        Parent = parent;
        Parent.AddPart(this);
    }
    
    private Part(Part part, Column parent)
    {
        Id = Guid.NewGuid();
        Name = $"{part.Name} copy";
        Width = part.Width;
        Height = part.Height;
        Highlighted = false;
        Done = false;
        Parent = parent;
        Parent.AddPart(this);
    }
    
    public void Reassign(Column newColumn)
    {
        if (newColumn.Parts.Contains(this)) return;

        Parent.RemovePart(this);
        Parent = newColumn;
        Parent.AddPart(this);
    }
    
    public void Delete()
    {
        Parent.RemovePart(this);
    }

    public void CopyTo(Column column)
    {
        new Part(this, column);
    }
}
