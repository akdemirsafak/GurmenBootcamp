using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class DALCacheFactory
    {

        public IDAL GetInstance()
        {
            return new DALCache();
        }
    }
}
