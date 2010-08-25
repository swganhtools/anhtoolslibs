using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utilities
{
    public class Log
    {
        /// <summary>
        /// Writes the specified message to the given file.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="TimeStamp">if set to <c>true</c> [time stamp].</param>
        public static void Write(string Message, string FileName, bool TimeStamp)
        {
            StreamWriter oWriter;

            oWriter = File.AppendText(FileName);

            if (TimeStamp == true)
                oWriter.Write(System.DateTime.Now.ToString() + ": ");

            oWriter.Write(Message);
            oWriter.Close();
        }

        /// <summary>
        /// Writes the line to the given file.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="FileName">Name of the file.</param>
        /// <param name="TimeStamp">if set to <c>true</c> [time stamp].</param>
        public static void WriteLine(string Message, string FileName, bool TimeStamp)
        {
            StreamWriter oWriter;

            oWriter = File.AppendText(FileName);

            if (TimeStamp == true)
                oWriter.Write(System.DateTime.Now.ToString() + ": ");

            oWriter.WriteLine(Message);
            oWriter.Close();
        }
    }//class
}
