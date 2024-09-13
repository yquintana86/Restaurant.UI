namespace SharedLib.Models.Common;

public class SelectItem
{
    public string Id { get; set; }

    public string Text { get; set; }

    public SelectItem Clone()
    {
        return new SelectItem { Id = this.Id, Text = this.Text };
    }
}
