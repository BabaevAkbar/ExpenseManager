namespace ExpenseApi.DTO.TransactionDtos.Request
{
    public class GetTransactionRequestDto
    {
        public Guid? Id{ get; set; }
        public Guid? CategoryId{ get; set; }
        public Types? Type{ get; set; }
    }
}