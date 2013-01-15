
namespace TopConfigTool.Util
{
    internal interface ILogger
    {
        void SetLoggerLevel(LoggerLevel level);

        void Error(string message);

        void Debug(string message);

        void Debug(string message, params object[] args);

        void Error(string message, params object[] args);

        void Trance(string message);

        void Trance(string message, params object[] args);
    }
}
