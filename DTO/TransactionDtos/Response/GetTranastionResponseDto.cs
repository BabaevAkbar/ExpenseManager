namespace ExpenseApi.DTO.TransactionDtos.Response
{
    public class GetTransactionResponseDto
    {
        public Guid? Id{ get; set; }
        public Guid? UserId{ get; set; }
        public Guid? CategoryId{ get; set; }
        public Types? Type{ get; set; }
        public string? CteateAt{ get; set; }
        public decimal? Amount{ get; set; }
        public string? Note{ get; set; }
        public decimal Balance{ get; set; }
    }
}