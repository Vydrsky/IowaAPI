using System.Net;

using Iowa.Application.Common.Exceptions.Base;

namespace Iowa.Application.Common.Exceptions;

public class SynchronousDatabaseOperationException : Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

    public string Title => "Synchronous database operation detected.";

    public string Detail => "This system does not allow for synchronous database access. Please use async method for commiting to database";
}
