using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MOHServer
{
    public class ServerLogHandler : IDisposable
    {
        private const string LOG_FOLDER = "logs";
        private const int MAX_LOG_FILES = 30;
        private const long MAX_LOG_SIZE = 10485760; // 10MB per log file
        private string m_currentLogFile;
        private StreamWriter m_logWriter;
        private bool m_disposed;
        private DateTime m_currentLogDate;

        public ServerLogHandler()
        {
            m_currentLogDate = DateTime.Now.Date;
            InitializeLogging();
        }

        private void InitializeLogging()
        {
            if (!Directory.Exists(LOG_FOLDER))
            {
                Directory.CreateDirectory(LOG_FOLDER);
            }

            RotateLogs();
            CreateNewLogFile();
        }

        private void CreateNewLogFile()
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            m_currentLogFile = Path.Combine(LOG_FOLDER, string.Format("server_{0}.log", timestamp));
            m_logWriter = new StreamWriter(m_currentLogFile, true, Encoding.UTF8);
            m_logWriter.AutoFlush = true;
            m_currentLogDate = DateTime.Now.Date;

            WriteLogHeader();
        }

        private void WriteLogHeader()
        {
            string[] serverInfo = new string[]
            {
                "=".PadRight(80, '='),
                string.Format("MOH Server Log Started at {0}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                string.Format("Log File: {0}", Path.GetFileName(m_currentLogFile)),
                "=".PadRight(80, '=')
            };

            foreach (string line in serverInfo)
            {
                m_logWriter.WriteLine(line);
            }
            m_logWriter.WriteLine();
        }

        private void RotateLogs()
        {
            List<string> logFiles = new List<string>(Directory.GetFiles(LOG_FOLDER, "server_*.log"));

            // Sort files by creation time (newest first)
            logFiles.Sort(delegate (string x, string y)
            {
                return File.GetCreationTime(y).CompareTo(File.GetCreationTime(x));
            });

            // Delete old logs if we have too many
            if (logFiles.Count > MAX_LOG_FILES)
            {
                for (int i = MAX_LOG_FILES; i < logFiles.Count; i++)
                {
                    try
                    {
                        File.Delete(logFiles[i]);
                    }
                    catch (IOException)
                    {
                        // Ignore deletion errors
                    }
                }
            }
        }

        private bool ShouldRotateLog()
        {
            if (m_logWriter == null || m_currentLogFile == null)
                return true;

            // Check if it's a new day
            if (DateTime.Now.Date != m_currentLogDate)
                return true;

            // Check if file size exceeds limit
            try
            {
                return new FileInfo(m_currentLogFile).Length > MAX_LOG_SIZE;
            }
            catch (IOException)
            {
                return true; // Rotate if we can't check the file size
            }
        }

        private void RotateLogIfNeeded()
        {
            if (ShouldRotateLog())
            {
                try
                {
                    if (m_logWriter != null)
                    {
                        m_logWriter.WriteLine("\nLog rotated at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        m_logWriter.WriteLine("=".PadRight(80, '='));
                        m_logWriter.Dispose();
                    }
                }
                catch (IOException)
                {
                    // Ignore errors during disposal
                }

                CreateNewLogFile();
                RotateLogs(); // Clean up old files after creating new one
            }
        }

        public void LogMessage(string message, Color color, FontStyle style)
        {
            if (m_disposed) return;

            try
            {
                RotateLogIfNeeded();

                string timestamp = DateTime.Now.ToString("HH:mm:ss");
                string stylePrefix = GetStylePrefix(style);
                string colorName = color.Name;

                // Format: [Time] {Color} {Style} Message
                string logLine = string.Format("[{0}] <{1}>{2}{3}", timestamp, colorName, stylePrefix, message);
                m_logWriter.WriteLine(logLine);
            }
            catch (IOException)
            {
                // Handle potential IO errors gracefully
            }
        }

        private string GetStylePrefix(FontStyle style)
        {
            List<string> styles = new List<string>();

            if ((style & FontStyle.Bold) == FontStyle.Bold)
                styles.Add("BOLD");
            if ((style & FontStyle.Italic) == FontStyle.Italic)
                styles.Add("ITALIC");

            return styles.Count > 0 ? string.Format("[{0}] ", string.Join(",", styles.ToArray())) : "";
        }

        public string[] GetRecentLogs(int count)
        {
            if (m_disposed) return new string[0];

            try
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(m_currentLogFile))
                {
                    List<string> allLines = new List<string>();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        allLines.Add(line);
                    }

                    // Get the last 'count' lines
                    int startIndex = Math.Max(0, allLines.Count - count);
                    for (int i = startIndex; i < allLines.Count; i++)
                    {
                        lines.Add(allLines[i]);
                    }
                }
                return lines.ToArray();
            }
            catch (IOException)
            {
                return new string[0];
            }
        }

        public void Dispose()
        {
            if (!m_disposed)
            {
                if (m_logWriter != null)
                {
                    try
                    {
                        m_logWriter.WriteLine("\nLog closed at: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        m_logWriter.WriteLine("=".PadRight(80, '='));
                        m_logWriter.Dispose();
                    }
                    catch (IOException)
                    {
                        // Ignore disposal errors
                    }
                }
                m_disposed = true;
            }
        }
    }
}