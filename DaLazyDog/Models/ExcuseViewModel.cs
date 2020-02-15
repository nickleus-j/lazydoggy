using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Lazydog.Model;

namespace DaLazyDog.Models
{
    public class ExcuseViewModel
    {
        Excuse Model { get; set; }
        public ExcuseViewModel(Excuse givenExcuse)
        {
            Model = givenExcuse;
        }
        [Display(Name = "Excuse")]
        public string ExcuseTitle => Model.ExcuseTitle;
        [Display(Name = "Description")]
        public string ExcuseDescription => Model.ExcuseDescription;
    }
}
