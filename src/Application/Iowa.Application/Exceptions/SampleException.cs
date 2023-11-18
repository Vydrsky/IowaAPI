using Iowa.Application.Exceptions.Base;
using System.Net;

namespace Iowa.Application.Exceptions {
    public class SampleException : Exception, IServiceException {
        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public string Title => "Sample Title";

        public string Detail => "Lorem ipsum dolor sit amet.";
    }
}