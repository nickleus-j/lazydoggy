using System.Collections.Generic;
using Lazydog.Model;
using Microsoft.Extensions.Logging;

namespace Lazydog.Model.Repo
{
    public interface ICultureRepo
    {
        IList<LocalizationCulture> GetSupportedCultures();
        void Log(LogLevel givenLogLevel, string msg);
    }
}