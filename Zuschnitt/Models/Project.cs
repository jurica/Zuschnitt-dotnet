using System.Text.Json.Serialization;

namespace Zuschnitt.Models;
public class Project 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Sheet> Sheets { get; set; }
    [JsonIgnore]
    public bool Editing { get; set; }

    public Project()
    {
        Id = Guid.NewGuid();
        Sheets = new ();
        Name = "";
        Editing = false;
        
        Sheets.Add(new Sheet());
    }
}
