using NLog;

namespace WebAPI_2
{
    public class LoggerManager : ILoggerManager
    {
        private static NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(Exception exception, string message) => logger.Error(exception, message);

        public void LogInfo(string message) => logger.Info(message);

        public void LogWarn(string message) => logger.Warn(message);
    }
}
