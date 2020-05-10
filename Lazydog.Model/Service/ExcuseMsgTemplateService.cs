using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lazydog.Model.Service
{
    /// <summary>
    /// Foe Excuse Message Data Services and apply Business logic on Message Entity
    /// </summary>
    public class ExcuseMsgTemplateService
    {
        public string GenerateSampleLetter()
        {
            return @"Hi, <br/>
            I `Name ~. wish to be excused for I have `Excuse ~. <br/>
            |FarewellWord ~, <br/>
            `Name";
        }
        private string ReplaceVariablesToHtmlTextBox(string regExPattern, string input)
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
        private string createSelectTagfromTemplate(string substringToReplace, IList<string> optionContent)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<select name='{0}'>", substringToReplace.Substring(1));
            foreach (string option in optionContent)
            {
                sb.AppendFormat("<option>{0}</option>", option);
            }
            sb.Append("</select>");
            return sb.ToString();
        }
        private IList<string> GenerateDefaultOptionsList()
        {
            IList<string> optionContent = new List<string>();
            optionContent.Add("Thanks");
            optionContent.Add("Sincerly");
            return optionContent;
        }
        private string ReplaceVariablesToHtmlDdl(string substringToReplace, string input, IList<string> optionContent = null)
        {
            if (optionContent == null)//Fallback
            {
                optionContent = GenerateDefaultOptionsList();
            }
            return input.Replace(substringToReplace, createSelectTagfromTemplate(substringToReplace, optionContent));
        }
        /// <summary>
        /// Replaces text matching a pattern with an HTMl Drop down list(ddl) or select tags
        /// </summary>
        /// <param name="templateString"></param>
        /// <param name="regExPattern"></param>
        /// <param name="OptionsList"></param>
        /// <returns></returns>
        private string ReplaceWordsForHtmlDdl(string templateString, string regExPattern, Dictionary<string, IList<string>> OptionsList)
        {
            Regex regexElements = new Regex(regExPattern, RegexOptions.IgnoreCase);
            string result = templateString;
            foreach (Match m in regexElements.Matches(templateString))
            {
                string ddlName = m.Value.Substring(1);
                IList<string> options;
                if (OptionsList.ContainsKey(ddlName))
                {
                    options = OptionsList[ddlName];
                }
                else
                {
                    options = null;
                }
                result = ReplaceVariablesToHtmlDdl(m.Value, result, options);
            }
            return result;
        }
        public string GenerateHtmlOfTemplate(string templateString,  Dictionary<string, IList<string>> OptionsList = null)
        {
            if (OptionsList == null)
            {
                OptionsList = new Dictionary<string, IList<string>>();
            }
            templateString = ReplaceWordsForHtmlDdl(templateString, @"[|]\w+", OptionsList);
            return ReplaceVariablesToHtmlTextBox(@"[`]\w+", templateString).Replace(" ~", String.Empty);
        }

    }
}
