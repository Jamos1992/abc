using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class RepoSpareToolManage
    {
        private RepoSpareToolService repoSpareToolService = new RepoSpareToolService();

        public RepoSpareTool QueryOneRepoSpare(string repoModel)
        {
            return repoSpareToolService.getOneRepoSpareToolFromDb(repoModel);
        }
    }
}
