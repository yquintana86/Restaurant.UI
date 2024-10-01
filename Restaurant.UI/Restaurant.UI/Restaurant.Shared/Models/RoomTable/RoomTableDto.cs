using System.Diagnostics.CodeAnalysis;

namespace SharedLib.Models.Shift;

public record RoomTableDto(int Id, int RoomId, [NotNull]string RoomName, RoomTableStatusType Status, int TotalQty, int? WaiterId, string? WaiterFullName);



