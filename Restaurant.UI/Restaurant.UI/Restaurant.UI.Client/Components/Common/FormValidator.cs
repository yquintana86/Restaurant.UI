using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Restaurant.UI.Client.Components.Common;

public class FormValidator : ComponentBase
{
    [CascadingParameter]
    private EditContext? CurrentEditContext { get; set; }

    private ValidationMessageStore? messageStore;

    protected override void OnInitialized()
    {
        if (CurrentEditContext is null)
        {
            throw new InvalidOperationException(
                $"{nameof(FormValidator)} requires a cascading " +
                $"parameter of type {nameof(EditContext)}. " +
                $"For example, you can use {nameof(FormValidator)} " +
                $"inside an {nameof(EditForm)}.");
        }

        messageStore = new(CurrentEditContext);
        
        CurrentEditContext.OnValidationRequested += (s, e) => 
            messageStore?.Clear();
        CurrentEditContext.OnFieldChanged += (s, e) =>
            messageStore?.Clear();
    }

    public void DisplayErrors(Dictionary<string, List<string>> errors)
    {
        if (CurrentEditContext is not null)
        {
            foreach (var error in errors)
            {
                messageStore?.Add(CurrentEditContext.Field(error.Key), error.Value);
            }

            CurrentEditContext.NotifyValidationStateChanged();
        }        
    }

    public void DisplayErrors( List<string> errors)
    {
        if (CurrentEditContext is not null)
        {
            foreach (var error in errors)
            {
                messageStore?.Add(CurrentEditContext.Field(""), error);
            }

            CurrentEditContext.NotifyValidationStateChanged();
        }
    }

    public void ClearErrors()
    {
        messageStore?.Clear();
        CurrentEditContext?.NotifyValidationStateChanged();
    }


}

