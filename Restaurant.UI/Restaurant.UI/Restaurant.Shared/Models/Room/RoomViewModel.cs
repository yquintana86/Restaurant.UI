using Restaurant.UI.Client.Models;

namespace SharedLib.Models.Room;

public class RoomViewModel : ISelfValidate
{

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int WaiterId { get; set; }
    public string? Theme { get; set; }
    public string? Description { get; set; }
    public string WaiterName { get; set; } = null!;

    public RoomInsertDto ToRoomInsertModel() =>
        new RoomInsertDto(Name, WaiterId, Theme, Description);

    public RoomUpdateDto ToRoomModel() =>
        new RoomUpdateDto(Id, Name, WaiterId, Theme, Description);

    public Dictionary<string, List<string>> Validate()
    {
        Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        if (string.IsNullOrWhiteSpace(Name))
            errors.Add(nameof(Name), new List<string>() { "A room name is required" });

        if (WaiterId == 0)
            errors.Add(nameof(Waiter), new List<string>() { "A responsible is required for the room" });

        return errors;
    }
    
}
