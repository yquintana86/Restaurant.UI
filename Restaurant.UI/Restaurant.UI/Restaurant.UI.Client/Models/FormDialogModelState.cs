namespace Restaurant.UI.Client.Models;

public class FormDialogModelState
{
    public FormDialogModelState()
    {
       Errors = new ();
       Warnings = new();
    }

    public bool Visible { get; set; }
    public bool Proccesing { get; set; }
    public List<string> Errors { get; set; }
    public List<string> Warnings{ get; set; }


    public void BegingProcessing()
    {
        Proccesing = true;
        Warnings.Clear();
        Errors.Clear();
    }

    public void Show()
    {
        Visible = true;
        Proccesing = false;
        Warnings.Clear();
        Errors.Clear();
    }

    public void Hide()
    {
        Visible = false;
        Proccesing = false;
        Warnings.Clear();
        Errors.Clear();
    }

    public void Processing()
    {
        Visible = true;
        Proccesing = true;
    }

    public void AddWarning(string warning)
    {
        Warnings.Add(warning);
    }

    public void AddWarnings(List<string> warnings)
    {
        Warnings.AddRange(warnings);
    }

    public void AddError(string error)
    {
        Errors.Add(error);
    }
    public void AddErrors(List<string> errors)
    {
        Errors.AddRange(errors);
    }

















}



