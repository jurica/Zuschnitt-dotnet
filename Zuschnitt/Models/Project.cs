using System.Text.Json.Serialization;

namespace Zuschnitt.Models;
public class Project 
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; set; } = "";
    public Sheet? SelectedSheet { get; set; }
    [JsonIgnore] public IEnumerable<Sheet> Sheets
    {
        get
        {
           foreach (var sheet in _sheets) yield return sheet;
        }
    }
    [JsonInclude] internal List<Sheet> _sheets { get; init; } = new();
    
    public void AddSheet()
    {
        new Sheet(){Parent = this};
    }

    public void RemoveSheet(Sheet sheet)
    {
        _sheets.Remove(sheet);
    }
}
