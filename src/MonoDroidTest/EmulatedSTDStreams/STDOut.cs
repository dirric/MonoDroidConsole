using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmulatedSTDStreams
{
    class STDOut
    {
        MemoryStream m_stdOut;
        StreamReader m_lineReader;

        public STDOut()
        {
            m_stdOut = new MemoryStream();
            m_lineReader = new StreamReader(m_stdOut);
        }

        public void WriteLine(string strOut)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(strOut);
            foreach (byte b in bytes)
            {
                m_stdOut.WriteByte(b);
            }
            m_stdOut.WriteByte((Encoding.ASCII.GetBytes("\n"))[0]);
        }

        public bool isAvailabile()
        {
            return m_stdOut.Length > 0;
        }

        internal string ReadLine()
        {
            return m_lineReader.ReadLine();
        }
    }
}