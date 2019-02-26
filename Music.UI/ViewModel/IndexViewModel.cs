using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.UI.ViewModel
{
    public class IndexViewModel
    {
        

        public IEnumerable<Music1> Msuic2{ get; set; }

        public IEnumerable<Articles > Articles1 { get; set; }

        public IEnumerable<List> List { get; set; }

        public IEnumerable<Users> Users { get; set; }

        public IEnumerable<Articles_Comment > Articles_Comment1 { get; set; }
    }
}