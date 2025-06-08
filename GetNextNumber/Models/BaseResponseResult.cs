

namespace GetNextNumber.Models;

public class BaseResponseResult
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public int StatusCode { get; set; }
}
public class BaseResponseResult<T> : BaseResponseResult
{
    public T? Data { get; set; }
}