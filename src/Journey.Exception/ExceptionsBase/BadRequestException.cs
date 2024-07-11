using System.Net;

namespace Journey.Exception.ExceptionsBase
{
    public class BadRequestException: JourneyException
    {
        private readonly IList<string> _errors;
        public BadRequestException(IList<string> messages) : base(string.Empty) 
        {
            _errors = messages;
        }

        public override IList<string> GetErrosMessages()
        {
            return _errors;
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
