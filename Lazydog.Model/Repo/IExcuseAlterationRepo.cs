using System;
using System.Collections.Generic;
using System.Text;
using Lazydog.Model;
using Microsoft.Extensions.Logging;

namespace Lazydog.Model.Repo
{
    public interface IExcuseAlterationRepo
    {
        void Log(LogLevel givenLogLevel, string msg);
        IList<ExcuseAlteration> GetExcuseAlteration(string title);
    }
}
