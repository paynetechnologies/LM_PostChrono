using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace ChronoService
{
    public class ErrorMessageX
    {
        public const string LogErrorFormat = "Error in the {0} method: {1}\n     Exception message: {2}";
    }

    public static class ManageLogX
    {
        private static log4net.ILog _log;

        /// <summary>
        /// Record an error message in the log file.
        /// </summary>
        /// <param name="message">The error message</param>
        public static void LogError(
            Exception exception,
            string errorMessage)
        {
            ConfigureLog();

            if (_log != null && _log.IsErrorEnabled)
            {
                _log.Error(
                    String.Format(ErrorMessageX.LogErrorFormat,
                    FindTheExceptionMethod(exception),
                    errorMessage,
                    TraverseExceptionMessages(exception)));
            }
        }
        /// <summary>
        /// Record an information message in the log file.
        /// </summary>
        /// <param name="message">The information message</param>
        public static void LogInfo(
            string message)
        {
            ConfigureLog();

            if (_log != null && _log.IsInfoEnabled)
            {
                _log.Info(message);
            }
        }

        /// <summary>
        /// Instantiate the log manager
        /// </summary>
        private static void ConfigureLog()
        {
            if (_log == null)
            {
                log4net.Config.XmlConfigurator.Configure();

                _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
        }


        /// <summary>
        /// Traverse and combine inner exception messages
        /// </summary>
        /// <param name="exception">An Exception instance</param>
        /// <returns>Exception messages</returns>
        public static string TraverseExceptionMessages(
            Exception exception)
        {
            string messages = String.Empty;
            Exception nextException = exception;

            while (nextException != null)
            {
                messages += "\n   " + nextException.Message;

                nextException = nextException.InnerException;
            }

            return messages;
        }

        /// <summary>
        /// Look for the initial method that caused the exception.
        /// </summary>
        /// <param name="exception">The exception thrown by a method.</param>
        /// <returns>The name of the method that threw the exception.</returns>
        private static string FindTheExceptionMethod(
            Exception exception)
        {
            string methodName = "?";

            if (exception != null && !String.IsNullOrEmpty(exception.StackTrace))
            {
                // Split the stack trace at each method call.
                string[] stacks = exception.StackTrace.Split(new string[] { " at " }, StringSplitOptions.RemoveEmptyEntries);

                if (stacks != null && stacks.Length > 0)
                {
                    // Select the first method call in the stack trace, which is the last method call in the collection.
                    // And split the first method call by the 'dot' notation.
                    string[] firstMethodCall = stacks[stacks.Length - 1].Split('.');

                    if (firstMethodCall != null && firstMethodCall.Length > 0)
                    {
                        foreach (string parts in firstMethodCall)
                        {
                            // Parse the collection of first method call parts to find the part that has an opening method brace.
                            if (parts.Contains('('))
                            {
                                // Assign the first element of the method parts colletion to the method name variable.
                                string[] methodParts = parts.Split('(');
                                methodName = methodParts[0];
                                break;
                            }
                        }
                    }
                }
            }

            return methodName;
        }
    }
}
