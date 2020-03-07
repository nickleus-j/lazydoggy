using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lazydog.Model.Service
{
    public class ExcuseMsgTemplateService
    {
        public string GenerateSampleLetter()
        {
            return @"Hi, 
            I `Name ~. wish to be excused for I have `Excuse ~.
            |FarewellWord ~,
            `Name";
        }
        public string GenerateHtmlOfTemplate(string templateString)
        {
            templateString = Regex.Replace(templateString, @"[`]\w+", "<input/>");
            return templateString.Replace(" ~", String.Empty);
        }
    }
}
