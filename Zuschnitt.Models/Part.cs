using System.Text.Json.Serialization;

namespace Zuschnitt.Models;

public class Part
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public int Width { get; set; } = 100;
    public int Height { get; set; } = 100;
    public bool Done { get; set; } = false;
    public required Column Parent
    {
        get => _parent;
        init
        {
            _parent = value;
            _parent._parts.Add(this);
        }
    }
    private Column _parent = null!;
    [JsonIgnore] public bool Highlighted { get; set; } = false;
    
    public void Reassign(Column newColumn)
    {
        if (newColumn.Parts.Contains(this)) return;

        Parent._parts.Remove(this);
        _parent = newColumn;
        Parent._parts.Add(this);
    }
    
    public void Delete()
    {
        Parent.RemovePart(this);
    }

    public void CopyTo(Column column)
    {
        var copy = new Part()
        {
            Parent = column,
            Height = this.Height,
            Width = this.Width,
            Name = $"{this.Name} copy",
        };
    }
}
