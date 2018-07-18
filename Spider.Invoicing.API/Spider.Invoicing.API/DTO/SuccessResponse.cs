using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.DTO
{
    public class SuccessResponse :ResponseBase<string>
    {
        public SuccessResponse()
        {
            this.Result = "Success";
        }
    }
}
