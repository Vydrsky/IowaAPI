using System.Net;

using Iowa.Domain._Common.Exceptions.Base;

namespace Iowa.Domain._Common.Exceptions;

public class CardListFullException : Exception, IDomainException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string Detail => "Game cannot have more than 4 cards at the same time";
}
