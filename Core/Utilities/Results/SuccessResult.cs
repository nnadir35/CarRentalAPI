namespace Core.Utilities.Results;

public class SuccessResult:Result
{
    public SuccessResult(bool success, string message) : base(true, message)
    {
    }

    public SuccessResult(string message) : base(true)
    {
    }
}