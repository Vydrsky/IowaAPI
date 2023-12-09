using System.Net;

using Iowa.Application.Common.Exceptions.Base;

namespace Iowa.Application.Common.Exceptions;

public class EntityNotFoundException : Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;

    public string Title => "Entity not found";

    public string Detail => "Specified entity could not be found in the database";
}
