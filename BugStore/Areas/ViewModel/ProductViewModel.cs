﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BugStore.Areas.ViewModel
{
    public class ProductViewModel
    {
        public string name { get; set; }
        public string image { get; set; }
        public string cat { get; set; }
        public string brand { get; set; }
        public int price { get; set; }
    }
}