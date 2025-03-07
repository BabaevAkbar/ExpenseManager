namespace ExpenseApi.DTO.TransactionDtos.Response
{
    public class TransactionResponseDto
    {
        public Guid Id{ get; set; }
        public Guid CategoryId{ get; set; }
        public string? CreateAt{ get; set; }
        public Types Type{ get; set; }
        public decimal Amount{ get; set; }
    }
}