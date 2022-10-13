using iTechArt.Domain.Entities.Police;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Service.Interfaces
{
    public interface IPoliceService
    {
        List<string> ImportOfficers();
        
        List<string> ExportOfficers();
    }
}
