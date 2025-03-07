namespace ExpenseApi.DTO.UserDtos.Response
{
    public class UserResponseDto
    {
        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public string Eamil{ get; set; }
        public string? CreateAt{ get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
    }
}