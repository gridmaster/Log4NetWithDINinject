using System;
using System.Globalization;
using LogWriter4.Core.Interface;

namespace LogWriter4.Logger
{
    class ConsoleLogger : ILogger
    {
        #region Properties and ILog Properties

        public LogLevelEnum LogLevel
        {
            get { return LogLevelEnum.Debug; }
            set { }
        }

        private string TimeStamp
        {
            get
            {
                string timeStamp = string.Format("{0:HH:mm:ss.fff}", DateTime.Now);
                return timeStamp;
            }
        }

        public bool IsDebugEnabled { get { return (LogLevel <= LogLevelEnum.Debug); } }
        public bool IsInfoEnabled { get { return (LogLevel <= LogLevelEnum.Info); } }
        public bool IsWarnEnabled { get { return (LogLevel <= LogLevelEnum.Warn); } }
        public bool IsErrorEnabled { get { return (LogLevel <= LogLevelEnum.Error); } }
        public bool IsFatalEnabled { get { return (LogLevel <= LogLevelEnum.Fatal); } }

        #endregion

        #region Constructor Methods

        static ConsoleLogger()
        {
        }

         #endregion

        #region public Methods

        public void Log(LogTypeEnum logLevel, string logMessage, params object[] args)
        {
            string message = new SystemStringFormat(CultureInfo.InvariantCulture, logMessage, args).ToString();
            Log(logLevel, message);
        }

         #endregion

        #region Private Methods

        private void Log(LogTypeEnum logLevel, string logMessage)
        {
            string prompt = string.Empty;

            switch (logLevel)
            {
                case LogWriter4.Logger.LogTypeEnum.DEBUG:
                    prompt = "Debug: {0}";
                    break;
                case LogWriter4.Logger.LogTypeEnum.ERROR:
                    prompt = "Error: {0}";
                    break;
                case LogWriter4.Logger.LogTypeEnum.FATAL:
                    prompt = "Fatal: {0}";
                    break;
                case LogWriter4.Logger.LogTypeEnum.INFO:
                    prompt = "Info: {0}";
                    break;
                case LogWriter4.Logger.LogTypeEnum.WARN:
                    prompt = "Warn: {0}";
                    break;
                default:
                    throw new NotSupportedException();
            }

            System.Diagnostics.Debug.Write(String.Format(prompt, logMessage));
        }

        #endregion

        #region ILogger Implementations

        public void Debug(object message)
        {
            Log(LogWriter4.Logger.LogTypeEnum.DEBUG, (string)message, null);
        }
        public void Debug(object message, Exception exception)
        {
            DebugFormat((string)message, exception);
        }
        public void DebugFormat(string format, params object[] args)
        {
            if (!IsDebugEnabled)
            {
                return;
            }

            string message = new SystemStringFormat(CultureInfo.InvariantCulture, format, args).ToString();
            Log(LogWriter4.Logger.LogTypeEnum.DEBUG, message, null);
        }

        public void Info(object message)
        {
            Log(LogWriter4.Logger.LogTypeEnum.INFO, (string)message, null);
        }
        public void Info(object message, Exception exception)
        {
            InfoFormat((string)message, exception);
        }
        public void InfoFormat(string format, params object[] args)
        {
            if (!IsInfoEnabled)
            {
                return;
            }

            string message = new SystemStringFormat(CultureInfo.InvariantCulture, format, args).ToString();
            Log(LogWriter4.Logger.LogTypeEnum.DEBUG, message, null);
        }
        public void Warn(object message)
        {
            Log(LogWriter4.Logger.LogTypeEnum.WARN, (string)message, null);
        }
        public void Warn(object message, Exception exception)
        {
            WarnFormat((string)message, exception);
        }
        public void WarnFormat(string format, params object[] args)
        {
            if (!IsWarnEnabled)
            {
                return;
            }

            string message = new SystemStringFormat(CultureInfo.InvariantCulture, format, args).ToString();
            Log(LogWriter4.Logger.LogTypeEnum.DEBUG, message, null);
        }

        public void Error(object message)
        {
            Log(LogWriter4.Logger.LogTypeEnum.ERROR, (string)message, null);
        }
        public void Error(object message, Exception exception)
        {
            ErrorFormat((string)message, exception);
        }
        public void ErrorFormat(string format, params object[] args)
        {
            if (!IsErrorEnabled)
            {
                return;
            }

            string message = new SystemStringFormat(CultureInfo.InvariantCulture, format, args).ToString();
            Log(LogWriter4.Logger.LogTypeEnum.DEBUG, message, null);
        }
        public void Fatal(object message)
        {
            Log(LogWriter4.Logger.LogTypeEnum.FATAL, (string)message, null);
        }
        public void Fatal(object message, Exception exception)
        {
            FatalFormat((string)message, exception);
        }
        public void FatalFormat(string format, params object[] args)
        {
            if (!IsFatalEnabled)
            {
                return;
            }

            string message = new SystemStringFormat(CultureInfo.InvariantCulture, format, args).ToString();
            Log(LogWriter4.Logger.LogTypeEnum.DEBUG, message, null);
        }

        #endregion
        
    }
}
