using DBLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class DirectoryModelView : PageModelView
    {
        public Directory Directory { get; set; }
        public List<ContentModelView> Books { get; set; }
    }

    public class DirectoryModelEdit : PageModelEdit
    {

    }
}
