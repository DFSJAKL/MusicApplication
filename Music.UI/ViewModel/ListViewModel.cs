using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.UI.ViewModel
{
    public class ListViewModel
    {
        public List List1 { get; set; } 

        public IEnumerable<List> List2 { get; set; }

        public IEnumerable<List_Comment> List_Comment { get; set; }

        public IEnumerable<List_Keep> List_Keep { get; set; }

        public IEnumerable<List_Music_Keep> List_Music_Keep { get; set; }

        public Music1 Music { get; set; } 
    }
}