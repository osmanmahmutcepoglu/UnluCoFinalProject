using System.Collections.Generic;

namespace UnluCoFinalProject.Domain.Common
{
    public class    AppResponse
    {
        public AppResponse()
        {
        }
        //public AppResponse(bool succeeded, string message,List<string> errors)
        //{
        //    Succeeded = succeeded;
        //    Message = message;
        //    Errors = errors;
        //}

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
