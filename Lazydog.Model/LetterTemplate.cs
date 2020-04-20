using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lazydog.Model
{
    public class LetterTemplate
    {
        public int ID { get; set; }
        [Display(Name = "Letter Template Content")]
        public string Content { get; set; }
        public string Meta { get; set; }
        [Display(Name = "Letter Template Name")]
        public string Name { get; set; }
        [Display(Name = "Can still be used")]
        public bool Active { get; set; }
    }
}
