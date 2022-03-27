using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class BL
    {
        public IDAL _dal { get; set; }

        public BL(IDAL dal)
        {
            _dal = dal;

        }

        public List<String> Products()
        {

            return _dal.GetAll();
        }


    }
}
