using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Interfaces
{
    public interface IGroceryService
    {
        List<string> ImportGrocery();
        List<string> ExportGrocery();
    }
}
