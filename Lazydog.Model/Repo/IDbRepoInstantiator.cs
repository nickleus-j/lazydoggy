using Lazydog.Model.Repo;
using Microsoft.Extensions.Logging;

namespace Lazydog.Model.Repo
{
    public interface IDbRepoInstantiator
    {
        string ConnectionString { get; set; }

        ICultureRepo GetCultureRepo(ILogger givenLogger = null);
        IExcuseRepo GetExcuseRepo(ILogger givenLogger = null);
        ILetterTemplateRepo GetLetterTemplateRepo(ILogger givenLogger = null);
        IExcuseAlterationRepo GetAlternateExcuseRepo(ILogger givenLogger = null);
    }
}