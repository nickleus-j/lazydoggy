using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lazydog.Model
{
    public class Excuse
    {
        [Display(Name = "Excuse")]
        public string ExcuseTitle { get; set; }
        [Display(Name = "Excuse Description")]
        public string ExcuseDescription { get; set; }
    }
}
