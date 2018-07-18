using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.DTO
{
    public abstract class ResponseBase<T>
    {
        public bool IsSuccess { get; set; }
        public Error Error { get; set; }
        public T Result { get; set; }
    }


    public class Error
    {
        public Error()
        {
            this.UUID = Guid.NewGuid().ToString();
        }
        public string Message { get; set; }
        public ErrorCodeEnum ErrorCode { get; set; }
        public string UUID { get; set; }
        public List<Error> Errors { get; set; }
    }

    public enum ErrorCodeEnum
    {
        UNKNOWN = 0,
        INVALID_REQUEST = 1,
        FORBIDDEN =2,
    }




}



