namespace Zuschnitt.Models;
public class Project 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Sheet> Sheets { get; set; }

    public Project()
    {
        Id = Guid.NewGuid();
        Sheets = new ();
        Name = "";
    }
}
