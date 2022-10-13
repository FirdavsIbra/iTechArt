using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArt.Data
{
    public class Response
    {
        public bool Success { get; set; } = true;

        public object Data { get; set; }

        public string Message { get; set; } = string.Empty;

    }
}
