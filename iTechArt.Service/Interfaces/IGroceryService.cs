using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Interfaces
{
    public interface IGroceryService
    {
        public List<string> ImportGrocery();
        public List<string> ExportGrocery();
    }
}
