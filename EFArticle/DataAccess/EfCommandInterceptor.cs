using System.Data.Common;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EFArticle.DataAccess
{
    public class EfCommandInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(
            DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            Debug.WriteLine(command.CommandText);
            return base.ReaderExecuting(command, eventData, result);
        }
    }
}