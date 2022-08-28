namespace Core.Utilities.Results;

public interface IResult
//temel voidler için
{
    bool Success { get; }
    public string Message { get; }
    
}