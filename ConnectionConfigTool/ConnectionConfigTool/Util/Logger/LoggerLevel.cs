using System.ComponentModel;

namespace TopConfigTool.Util
{
    internal enum LoggerLevel
    {
        [Description("NoLog")]
        NoLog = 0,
        [Description("Trance")]
        Trance = 1,
        [Description("Debug")]
        Debug = 2,
        [Description("Error")]
        Error = 3,
    }
}
