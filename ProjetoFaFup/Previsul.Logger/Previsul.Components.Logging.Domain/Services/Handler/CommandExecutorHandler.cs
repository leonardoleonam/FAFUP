using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Previsul.Components.Logging.Domain.Services.Handler
{
    public static class CommandExecutorHandler
    {
        public static Task ExecuteAsync(Func<Task> function)
        {
            try
            {
                return function();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
                return null;
            }
        }

        public static void Execute(Func<object> function)
        {
            try
            {
                function();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }
    }
}
