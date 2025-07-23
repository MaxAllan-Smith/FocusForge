using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusForge.Application.Commands
{
    public class CompleteTaskCommand(Guid id)
    {
        public Guid Id { get; } = id;
    }
}
