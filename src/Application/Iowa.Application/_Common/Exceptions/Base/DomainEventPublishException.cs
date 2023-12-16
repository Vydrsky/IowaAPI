using System.Net;

using Iowa.Application.Common.Exceptions.Base;

namespace Iowa.Application._Common.Exceptions.Base;

public class DomainEventPublishException : Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

    public string Title => "Problem with domain event publishing";

    public string Detail => "Chain of events could not be resolved, database transaction canelled.";
}
