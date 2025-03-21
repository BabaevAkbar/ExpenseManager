namespace Responses
{
    public class ApiResponse<T>
    {
        public bool Success{ get; set; }
        public T Data{ get; set; }
        public string? Message{ get; set; }
        public ApiResponse(T data, string message = null)
        {
            Success = true;
            Data = data;
            Message = message;
        }

        public ApiResponse(User user, string message)
        {
            Success = false;
            Message = message;
        }
    }
}