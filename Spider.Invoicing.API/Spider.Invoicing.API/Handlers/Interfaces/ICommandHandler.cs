using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spider.Invoicing.API.DTO;

namespace Spider.Invoicing.API.Handlers.Interfaces
{
    interface ICommandHandler<T> where T : ICommand
    {
        Task<IResponse> Handle(T command);
    }
}
