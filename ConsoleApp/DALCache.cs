using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class DALCache : IDAL
    {
        public List<string> GetAll()
        {
            return new List<string>() { "Cache Kalem 1", "Cache Kalem 2" };
        }
    }
}
