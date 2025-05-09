using System;
using System.Collections.Generic;
using System.Text;

namespace Dto.Model.Common
{
    public class Response 
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public string ex { get; set; }
    }
    public enum ErrorStatus
    {
        Success = 200,
        Error = 400,
        Exception = 500,
        NotFound = 404
    }
}
