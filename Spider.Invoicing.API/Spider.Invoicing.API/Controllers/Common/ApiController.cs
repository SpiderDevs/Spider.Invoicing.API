using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Spider.Invoicing.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spider.Invoicing.API.Controllers.Common
{
    public class ApiController : Controller
    {        
        internal IActionResult Response(ResponseBase response)
        {
            if(response.IsSuccess)
            {
                return new OkObjectResult(response);
            }
            else
            {
                var result = new ObjectResult(response);
                result.StatusCode = GetHttpStatusCode(response?.Error?.ErrorCode);
                return result;
            }
        }

        private int GetHttpStatusCode(ErrorCodeEnum? errorCode)
        {
            switch(errorCode)
            {
                case ErrorCodeEnum.INVALID_REQUEST:
                    return StatusCodes.Status400BadRequest;
                case ErrorCodeEnum.FORBIDDEN:
                    return StatusCodes.Status403Forbidden;
                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }


        //internal ObjectResult ApiOk()
        //{
        //    return new OkObjectResult(new SuccessResponse());
        //}

        //internal ObjectResult ApiCreated()
        //{
        //    var result = new OkObjectResult(new SuccessResponse());
        //    result.StatusCode = StatusCodes.Status201Created;
        //    return result;
        //}

        //internal ObjectResult ApiOk(ResponseBase response)
        //{
        //    return Ok(response);
        //}

        //internal ObjectResult ApiBadRequest(ResponseBase response)
        //{
        //    return BadRequest(response);
        //}
    }
}
