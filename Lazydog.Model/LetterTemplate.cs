using System;
using System.Collections.Generic;
using System.Text;

namespace Lazydog.Model
{
    public class LetterTemplate
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public string Meta { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
