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
    public class Music_CommentBll
    {
        public IMusic_Comment imusic_comment = DataAccess.CreateMusic_Comment();
        public IEnumerable<Music_Comment> GetPC(int mcid)
        {
            return imusic_comment.GetPC(mcid);
        }
        public void InsertPC(Music_Comment mcmes)
        {
            imusic_comment.InsertPC(mcmes);
        }
        public int Music_CommentCount(int mcid)
        {
            return imusic_comment.Music_CommentCount(mcid);
        }
    }
}
