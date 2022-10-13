using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Interfaces
{
    public interface IPupilService
    {
        IEnumerable<string> ImportPupilsFile();
        IEnumerable<string> ExportPupilsFile();
    }
}
