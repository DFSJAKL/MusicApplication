﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.UI.ViewModel
{
    public class ArticlesViewModel
    {
        public Articles Articles1 { get; set; }

        public IEnumerable<List> Musics { get; set; }

        public IEnumerable<List> List2 { get; set; }

        public IEnumerable<Articles> Articles2 { get; set; }

        public IEnumerable<Articles_Comment> Articles_Comment { get; set; }

        public IEnumerable<Music1> Msuic2 { get; set; }

        public IEnumerable<List> List { get; set; }
    }
}