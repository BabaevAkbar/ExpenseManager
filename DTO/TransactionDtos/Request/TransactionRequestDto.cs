namespace ExpenseApi.DTO.TransactionDtos.Request
{
    public class TransactionRequestDto
    {
        public Guid CategoryId{ get; set; }
        public decimal Amount{ get; set; }
        public Types Type{ get; set; }
        public string? Note{ get; set; }
    }
}