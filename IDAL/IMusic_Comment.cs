using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IMusic_Comment
    {

        IEnumerable<Music_Comment> GetPC(int mcid);
        void InsertPC(Music_Comment mcmes);
        int Music_CommentCount(int mcid);
    }
}

