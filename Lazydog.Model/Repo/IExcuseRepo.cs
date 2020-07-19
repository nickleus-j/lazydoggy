using System.Collections.Generic;
using Lazydog.Model;
using Microsoft.Extensions.Logging;

namespace Lazydog.Model.Repo
{
    public interface IExcuseRepo
    {
        Excuse GetAnExcuse();
        IList<Excuse> GetExcuses();
        IList<Excuse> GetExcuses(string label);
        List<string> GetExcuseTitles();
        string GetRandomExcuse();
        void Log(LogLevel givenLogLevel, string msg);
    }
}