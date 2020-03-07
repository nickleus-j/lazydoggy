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
            return @"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
        }
        private string ReplaceVariablesToHtmlTextBox(string regExPattern,string input)
        {
            string templateString = input;
            Regex regexElements = new Regex(regExPattern, RegexOptions.IgnoreCase);

            foreach (Match m in regexElements.Matches(templateString))
            {
                string textboxName = m.Value.Substring(1);
                templateString = templateString.Replace(m.Value, String.Format("<input type=\"text\" placeholder=\"{0}\" name=\"{0}\"/>", textboxName));
            }
            return templateString;
        }
        public string GenerateHtmlOfTemplate(string templateString)
        {
            return ReplaceVariablesToHtmlTextBox(@"[`]\w+", templateString).Replace(" ~", String.Empty);
        }
        
    }
}
