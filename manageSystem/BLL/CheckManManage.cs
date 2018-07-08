using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class CheckManManage
    {
        private CheckManService checkManService = new CheckManService();
        public int AddOneName(string name)
        {
            return checkManService.InsertCheckMan(name);
        }

        public List<CheckMan> GetAllName()
        {
            return checkManService.GetAllCheckMan();
        }
    }
}
