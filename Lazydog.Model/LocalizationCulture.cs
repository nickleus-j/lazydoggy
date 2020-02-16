using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Lazydog.Model
{
    public class LocalizationCulture
    {
        [MaxLength(10)]
        [Display(Name = "Culture Code", Description ="The Culture Code of the supported location")]
        public string CultureCode { get; set; }
        [Display(Name = "Culture Name", Description = "The Culture Name of the supported location")]
        public string CultureName { get; set; }
    }
}
