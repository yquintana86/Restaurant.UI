namespace SharedLib.Models.Shift;

public record RoomTableUpdateDto(int Id, int RoomId, RoomTableStatusType Status, int? WaiterId, int TotalQty); 



