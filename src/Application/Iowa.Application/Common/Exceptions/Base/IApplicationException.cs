using System.Net;

namespace Iowa.Application.Common.Exceptions.Base;

public interface IApplicationException
{
    HttpStatusCode StatusCode { get; }
    string Title { get; }
    string Detail { get; }
}
