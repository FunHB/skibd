using Markdig;

namespace skibd.API.Models;

public class Report
{
    public int Id { get; set; }
    public string PathToFile { get; set; }
    public DateTime Date { get; set; }
    public string Content => File.ReadAllText(PathToFile);
    public string MarkDown => Markdown.ToHtml(Content);

    public Report(string path)
    {
        PathToFile = path;
        Id = int.Parse(Path.GetFileNameWithoutExtension(PathToFile));
        Date = new DateTime(2023, 3, 7).AddDays((Id - 1) * 7);
    }
}
