using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Application.Common.Exceptions
{
    internal class NotFoundException: Exception
    {
        public NotFoundException(string name, object key): base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
