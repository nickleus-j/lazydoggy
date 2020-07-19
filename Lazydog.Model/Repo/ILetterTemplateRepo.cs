using System.Collections.Generic;
using Lazydog.Model;
using Microsoft.Extensions.Logging;

namespace Lazydog.Model.Repo
{
    public interface ILetterTemplateRepo
    {
        LetterTemplate GetLetterTemplate(int id);
        LetterTemplate GetLetterTemplateInHtmlForm(int id);
        IList<LetterTemplate> GetLetterTemplates();
        void Log(LogLevel givenLogLevel, string msg);
    }
}