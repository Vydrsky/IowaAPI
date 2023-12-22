using System.Net;

namespace Iowa.Domain._Common.Exceptions.Base;

public interface IDomainException
{
    HttpStatusCode StatusCode { get; }
    string Detail { get; }
}
