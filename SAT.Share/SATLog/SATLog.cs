using NLog;

namespace SAT.Share.SATLog
{
    public class SATLog
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        public static void Trace_Log(string Message)
        {
            Logger.Trace(Message);
        }

        public static void Debug_Log(string Message)
        {
            Logger.Debug(Message);
        }

        public static void Info_Log(string Message)
        {
            Logger.Info(Message);
        }

        public static void Warn_Log(string Message)
        {
            Logger.Warn(Message);
        }

        public static void Error_Log(string Message)
        {
            Logger.Error(Message);
        }

        public static void Fatal_Log(string Message)
        {
            Logger.Fatal(Message);
        }
    }
}