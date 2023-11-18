using System.Net;

namespace Iowa.Application.Exceptions.Base; 

public interface IServiceException {
    HttpStatusCode StatusCode { get; }
    string Title { get; }
    string Detail { get; }
}
