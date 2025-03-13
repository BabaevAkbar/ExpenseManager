namespace ExpenseApi.DTO.CategoryDtos.Response
{
    public class CategoryResponseDto
    {
        public Guid Id{ get; set; }
        public Guid UserID{ get; set; }
        public string? Name{ get; set; }
        public string CreateAt{ get; set; }

    }
}