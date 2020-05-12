using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class PageModelView
    {

    }

    public class PageModelEdit
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Html { get; set; }
    }
}
