using NLog;

namespace SAT.Core.Common
{
    public class SATLog
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 控制台打印
        /// </summary>
        /// <param name="Message"></param>
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

        /// <summary>
        /// 独属错误日志
        /// </summary>
        /// <param name="Message"></param>
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