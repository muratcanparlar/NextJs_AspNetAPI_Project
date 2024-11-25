namespace Ginosis.Common.Application.Exceptions;

public class GinosisException : Exception
{
    public GinosisException(string requestName, Error? error = default, Exception? innerException = default)
        : base("Application exception", innerException)
    {
        RequestName = requestName;
        Error = error;
    }
    public string RequestName { get; }

    public Error? Error { get; }
}

