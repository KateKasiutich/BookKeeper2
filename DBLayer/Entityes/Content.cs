using System;
using System.Collections.Generic;
using System.Text;

namespace DBLayer.Entityes
{
    public class Content : Page
    {
        public int DirectoryId { get; set; }
        public Directory Directory { get; set; }
    }
}
