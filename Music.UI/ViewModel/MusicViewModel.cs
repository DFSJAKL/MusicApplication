using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.UI.ViewModel
{
    public class MusicViewModel
    {
        public IEnumerable<Music_Type> Type1 { get; set; }

        public Articles Articles1 { get; set; }

        public IEnumerable<Music1 > Musics { get; set; }

        public IEnumerable<Music1> Musics1 { get; set; }

        public Music1 Music2 { get; set; }

        public IEnumerable<List> List1 { get; set; }

        public IEnumerable<List> List2 { get; set; }

        public IEnumerable<Music_Comment> Music_Comment { get; set; }

        //public IEnumerable<Music_Comment_Comment> Music_Comment_Comment { get; set; }

      

    }
}