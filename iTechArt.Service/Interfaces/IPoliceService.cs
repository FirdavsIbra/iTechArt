using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Interfaces
{
    public interface IPoliceService
    {
        List<string> ImportPolice();
        List<string> ExportPolice();
    }
}
