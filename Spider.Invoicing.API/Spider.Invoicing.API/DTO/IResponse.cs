using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.DTO
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }
        Error Error { get; set; }
    }
}
