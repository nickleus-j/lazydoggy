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
        [Display(Name = "Description")]
        public string ExcuseDescription { get; set; }
        [Display(Name = "Labels")]
        public string Labels { get; set; }
        public string[] LabelArr
        {
            get
            {
                return Labels!=null? Labels.Split(','):new string[1];
            }
        }
    }
}
