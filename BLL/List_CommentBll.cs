using DALFactory;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class List_CommentBll : BaseManager<List_Comment>
    {
        public override IBase<List_Comment> GetDal()
        {
            return DataAccess.CreateList_Comment();
        }
    }
}
