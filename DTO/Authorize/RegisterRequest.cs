namespace ExpenseApi.DTO.UserDtos.Authorize
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email{ get; set; }
        public string? Name{ get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Пароль должен содержать минимум 6 символов")]
        public string Password{ get; set; }
    }
}