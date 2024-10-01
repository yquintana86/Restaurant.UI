using Restaurant.UI.Client.Models;

namespace SharedLib.Models.Shift;


public class RoomTableViewModel : ISelfValidate
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public string RoomName { get; set; } = null!;
    public RoomTableStatusType Status { get; set; }
    public int TotalQty { get; set; } = 2;
    public int? WaiterId { get; set; }
    public string? WaiterFullName { get; set; }
    public bool HasResponsible { get; set; }

    public Dictionary<string, List<string>> Validate()
    {
        var errors = new Dictionary<string, List<string>>();

        if (RoomId == 0)
            errors.Add(nameof(RoomId), new List<string>() { $" The room where the table is located is required" });

        if(TotalQty < 2)
            errors.Add(nameof(TotalQty), new List<string>() { $"Table capacity should be greather than one" });

        if(HasResponsible && !WaiterId.HasValue)
            errors.Add(nameof(WaiterId),new List<string>() { "A waiter is required if the room table has responsible" });

        return errors;
    }

    public RoomTableInsertDto ToRoomTableInsertModel() => 
        new RoomTableInsertDto(RoomId, WaiterId, TotalQty);


    public RoomTableUpdateDto ToRoomTableModel() => 
        new RoomTableUpdateDto(Id, RoomId, Status, WaiterId, TotalQty);
    
}



