using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Restaurant.UI.Client.Shared;

public class PageBase : ComponentBase
{
    [Inject]
    protected NavigationManager _navigationManager { get; set; } = null!;

    [Inject]
    protected IJSRuntime _jsHelper { get; set; } = null!;

    [Inject]
    protected HttpClient _httpClient { get; set; } = null!;

    protected async Task ToastSuccess(string title, string message)
    {
        await _jsHelper.InvokeAsync<object>("NotifyToast", title, message);
    }

    protected async Task ToastError(string message)
    {
        await _jsHelper.InvokeAsync<object>("NotifyToast", "Error", message);
    }
}
