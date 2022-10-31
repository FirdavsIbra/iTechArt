using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Domain.ModelInterfaces.HelperModelInterfaces
{
    public interface IDbResult
    {
        public bool IsSuccess { get; }
        public Exception Exception { get; }
    }
}
