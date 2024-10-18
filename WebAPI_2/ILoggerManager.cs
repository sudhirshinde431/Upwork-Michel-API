namespace WebAPI_2
{
    public interface ILoggerManager
    {
        void LogInfo(string message);
        void LogWarn(string message);
        void LogDebug(string message);
        void LogError(Exception exception, string message);
    }
}
