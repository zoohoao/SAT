namespace SAT.Interface.Common
{
    public interface ISATLog
    {
        void Trace_Log(string Message);

        void Debug_Log(string Message);

        void Info_Log(string Message);

        void Warn_Log(string Message);

        void Fatal_Log(string Message);
    }
}