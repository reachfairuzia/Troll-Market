using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrollMarket.ViewModel
{
    public class JsonResultViewModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object ReturnObject { get; set; }
    }
}
