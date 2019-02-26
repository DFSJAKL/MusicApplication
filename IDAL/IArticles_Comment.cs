using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IArticles_Comment:IBase<Articles_Comment>
    {
        void InsertAC(Articles_Comment AC);
    }
}
