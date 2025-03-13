namespace ExpenseApi.DTO.UserDtos.Request
{
    public record struct UserRequestDto(Guid UserId, string Name);
}