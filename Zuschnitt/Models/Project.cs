using System.Text.Json.Serialization;

namespace Zuschnitt.Models;
public class Project 
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Sheet> Sheets
    {
        get
        {
           foreach (var sheet in _sheets) yield return sheet;
        }
    } 
    [JsonIgnore] public bool Editing { get; set; }
    private readonly List<Sheet> _sheets = new();

    public Project()
    {
        Id = Guid.NewGuid();
        Name = "";
        Editing = false;
        
        AddSheet();
    }

    public void AddSheet()
    {
       _sheets.Add(new Sheet());
    }

    public void AddSheet(Sheet sheet)
    {
        _sheets.Add(sheet);
    }

    public void RemoveSheet(Sheet sheet)
    {
        _sheets.Remove(sheet);
    }
}
