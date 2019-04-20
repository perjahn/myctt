using Microsoft.Web.XmlTransform;
using System;

namespace myctt
{
    class MyLogger : IXmlTransformationLogger
    {
        public void EndSection(string message, params object[] messageArgs)
        {
            Log($"EndSection: {string.Format(message, messageArgs)}");
        }

        public void EndSection(MessageType type, string message, params object[] messageArgs)
        {
            Log($"EndSection ({type}): {string.Format(message, messageArgs)}");
        }

        public void LogError(string message, params object[] messageArgs)
        {
            Log($"Error: {string.Format(message, messageArgs)}", ConsoleColor.Red);
        }

        public void LogError(string file, string message, params object[] messageArgs)
        {
            Log($"Error: file: {file}, {string.Format(message, messageArgs)}", ConsoleColor.Red);
        }

        public void LogError(string file, int lineNumber, int linePosition, string message, params object[] messageArgs)
        {
            Log($"Error: file: {file} (line {lineNumber}, {linePosition}), {string.Format(message, messageArgs)}", ConsoleColor.Red);
        }

        public void LogErrorFromException(Exception ex)
        {
            Log($"ErrorFromException: ex: {ex.ToString()}", ConsoleColor.Red);
        }

        public void LogErrorFromException(Exception ex, string file)
        {
            Log($"ErrorFromException: ex: {ex.ToString()}{Environment.NewLine}File: {file}", ConsoleColor.Red);
        }

        public void LogErrorFromException(Exception ex, string file, int lineNumber, int linePosition)
        {
            Log($"ErrorFromException: ex: {ex.ToString()}{Environment.NewLine}File: {file} (line {lineNumber}, {linePosition})", ConsoleColor.Red);
        }

        public void LogMessage(string message, params object[] messageArgs)
        {
            Log($"Message: {string.Format(message, messageArgs)}");
        }

        public void LogMessage(MessageType type, string message, params object[] messageArgs)
        {
            Log($"Message ({type}): {string.Format(message, messageArgs)}");
        }

        public void LogWarning(string message, params object[] messageArgs)
        {
            Log($"Warning: {string.Format(message, messageArgs)}", ConsoleColor.Yellow);
        }

        public void LogWarning(string file, string message, params object[] messageArgs)
        {
            Log($"Warning: file: {file}, {string.Format(message, messageArgs)}", ConsoleColor.Yellow);
        }

        public void LogWarning(string file, int lineNumber, int linePosition, string message, params object[] messageArgs)
        {
            Log($"Warning: file: {file} (line {lineNumber}, {linePosition}), {string.Format(message, messageArgs)}", ConsoleColor.Yellow);
        }

        public void StartSection(string message, params object[] messageArgs)
        {
            Log("StartSection");
        }

        public void StartSection(MessageType type, string message, params object[] messageArgs)
        {
            Log($"StartSection ({type}): {string.Format(message, messageArgs)}");
        }

        void Log(string message)
        {
            Console.WriteLine(message);
        }

        void Log(string message, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            try
            {
                Console.ForegroundColor = color;
                Console.WriteLine(message);
            }
            finally
            {
                Console.ForegroundColor = oldColor;
            }
        }
    }
}
