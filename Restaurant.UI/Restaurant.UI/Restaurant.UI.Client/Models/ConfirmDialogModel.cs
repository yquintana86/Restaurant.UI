namespace Restaurant.UI.Client.Models;

public class ConfirmDialogModel
{
    public string Title { get; set; } = "";
    public string Heading { get; set; } = "Are you sure?";
    public string IconClass { get; set; } = "fa fa-exclamation-triangle";
    public string IconClassColor { get; set; } = "text-warning";
    public string IconHeightClass { get; set; } = "fa-2x";
    public string AcceptBtnTxt { get; set; } = "Accept";
    public string CancelBtnTxt { get; set; } = "Cancel";
    public List<string> Warnings { get; set; } = new();
}



