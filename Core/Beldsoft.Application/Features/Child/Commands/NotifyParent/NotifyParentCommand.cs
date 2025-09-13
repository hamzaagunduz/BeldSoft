using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Commands.NotifyParent
{
    public record NotifyParentCommand(int ChildId, string ChildName) : IRequest;


}
