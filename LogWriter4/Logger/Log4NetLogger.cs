﻿using System;
using System.Globalization;
using log4net;
using LogWriter4.Core.Interface;

namespace LogWriter4.Logger
{
    public sealed class Log4NetLogger : ILogger
    {
        #region Properties and ILog Properties

        private static readonly log4net.ILog _log;

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

        static Log4NetLogger()
        {
            _log = LogManager.GetLogger("Log4NetLogger");
            log4net.Config.XmlConfigurator.Configure();
        }

        #endregion

        #region public methods

        public void Log(LogTypeEnum logLevel, string logMessage, params object[] args)
        {
            string message = new SystemStringFormat(CultureInfo.InvariantCulture, logMessage, args).ToString();
            Log(logLevel, message);
        }

        #endregion

        #region Private Methods

        private void Log(LogTypeEnum logLevel, string logMessage)
        {
            switch (logLevel)
            {
                case LogTypeEnum.DEBUG:
                    _log.Debug(logMessage);
                    break;
                case LogTypeEnum.ERROR:
                    _log.Error(logMessage);
                    break;
                case LogTypeEnum.FATAL:
                    _log.Fatal(logMessage);
                    break;
                case LogTypeEnum.INFO:
                    _log.Info(logMessage);
                    break;
                case LogTypeEnum.WARN:
                    _log.Warn(logMessage);
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        #endregion
        
        #region ILogger Implementations

        public void Debug(object message)
        {
            if (!IsDebugEnabled)
            {
                return;
            }
            Log(LogTypeEnum.DEBUG, (string)message, null);
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
            Log(LogTypeEnum.DEBUG, message, null);
        }

        public void Info(object message)
        {
            if (!IsInfoEnabled)
            {
                return;
            }
            Log(LogTypeEnum.INFO, (string)message, null);
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
            Log(LogTypeEnum.DEBUG, message, null);
        }

        public void Warn(object message)
        {
            if (!IsWarnEnabled)
            {
                return;
            }
            Log(LogTypeEnum.WARN, (string)message, null);
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
            Log(LogTypeEnum.DEBUG, message, null);
        }

        public void Error(object message)
        {
            if (!IsErrorEnabled)
            {
                return;
            }
            Log(LogTypeEnum.ERROR, (string)message, null);
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
            Log(LogTypeEnum.DEBUG, message, null);
        }
        public void Fatal(object message)
        {
            if (!IsFatalEnabled)
            {
                return;
            }
            Log(LogTypeEnum.FATAL, (string)message, null);
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
            Log(LogTypeEnum.DEBUG, message, null);
        }

        #endregion
        
    }
}