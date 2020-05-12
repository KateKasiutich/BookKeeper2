using DBLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class ContentModelView : PageModelView
    {
        public Content Content { get; set; }
        public Content NextContent { get; set; }
    }

    public class ContentModelEdit : PageModelEdit
    {
        [Required]
        public int DirectoryId { get; set; }
    }
}
