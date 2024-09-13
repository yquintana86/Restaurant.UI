using Microsoft.AspNetCore.Components;

namespace Restaurant.UI.Client.Models;

public class FormDialogModel<T>
{
    public FormDialogModel()
    {
        State = new();
    }

    public FormDialogModelState State { get; set; }
    public T? Model { get; set; }
}



