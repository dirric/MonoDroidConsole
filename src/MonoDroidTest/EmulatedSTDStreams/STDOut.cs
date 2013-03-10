using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmulatedSTDStreams
{
    public static class STDOut
    {
        static MemoryStream m_stdOutWrite;
        static MemoryStream m_stdOutRead;
        static StreamReader m_lineReader;
        static StreamWriter m_lineWriter;
        static byte[] m_buf;

        static STDOut()
        {
            m_buf = new byte[512];
            m_stdOutWrite = new MemoryStream(m_buf, true);
            m_stdOutRead = new MemoryStream(m_buf, false);
            m_lineReader = new StreamReader(m_stdOutRead, Encoding.ASCII);
            m_lineWriter = new StreamWriter(m_stdOutWrite, Encoding.ASCII);
        }

        public static void WriteLine(string strOut)
        {
            m_lineWriter.WriteLine(strOut);
            m_lineWriter.Flush();
        }

        public static bool isAvailabile()
        {
            return m_stdOutRead.Length > 0;
        }

        internal static string ReadLine()
        {
            return m_lineReader.ReadLine();
        }
    }
}