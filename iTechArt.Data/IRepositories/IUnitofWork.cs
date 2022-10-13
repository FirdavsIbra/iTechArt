using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Data.IRepositories
{
    public interface IUnitofWork
    {
        IPoliceRepository Police { get; }
    }
}
