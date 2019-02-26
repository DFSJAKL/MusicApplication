using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.UI.ViewModel
{
    public class List_Music_KeepViewModel
    {
        public List_Music_Keep List_Music_Keep1 { get; set; }

        public IEnumerable<List_Music_Keep> List_Music_Keep2 { get; set; }

        public IEnumerable<Music1 > Musics { get; set; }

        public IEnumerable<List > List{ get; set; }
    }
}