using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class DAL : IDAL
    {

        public List<String> GetAll()
        {

            return new List<string>() { "Kalem 1", "Kalem 2", "Kalem 3" };
        }
    }
}
