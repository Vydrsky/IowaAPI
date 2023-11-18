using Iowa.Application.Common.Exceptions.Base;
using System.Net;

namespace Iowa.Application.Common.Exceptions;

public class SampleException : Exception, IApplicationException
{
    public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

    public string Title => "Sample";

    public string Detail => "Lorem ipsum dolor sit amet.";
}