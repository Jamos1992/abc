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

        public bool IsNameExist(string name)
        {
            return checkManService.GetCheckManByName(name) != null;
        }

        public int DeleteOneWorker(string name)
        {
            return checkManService.DeleteOneWorker(name);
        }

        public List<CheckMan> GetAllName()
        {
            return checkManService.GetAllCheckMan();
        }
    }
}
