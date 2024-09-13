namespace Restaurant.UI.Client.Models;

public interface ISelfValidate
{
    Dictionary<string, List<string>> Validate();

}
