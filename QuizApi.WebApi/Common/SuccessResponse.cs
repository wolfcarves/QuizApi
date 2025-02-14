public class SuccessResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string? Message { get; set; }

    public SuccessResponse(T data, string? message)
    {
        Success = true;
        Data = data;
        Message = message; 
    }

    public SuccessResponse(string message)
    {
        Success = true;
        Message = message;
    }
}