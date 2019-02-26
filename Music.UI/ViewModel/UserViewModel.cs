using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.UI.ViewModel
{
    
        public class UserViewModel
        {
            public Users User1 { get; set; }

            public IEnumerable<List> List1 { get; set; }

            public IEnumerable<List_Keep> List_Keep1 { get; set; }

            //public IEnumerable<Attention> Attention1 { get; set; }

            //public IEnumerable<Attention> Attention2 { get; set; }

            public IEnumerable<Music1> Music2 { get; set; }
        }
}