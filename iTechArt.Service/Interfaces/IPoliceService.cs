using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Interfaces
{
    public interface IPoliceService
    {
        public List<string> ImportPolice();
        public List<string> ExportPolice();
    }
}
