using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmulatedSTDStreams
{
    public class STDIn
    {
        MemoryStream m_inStream;

        public void WriteLine(string strOut)
        {
            byte []bytes = Encoding.ASCII.GetBytes(strOut);
            foreach(byte b in bytes)
            {
                m_inStream.WriteByte(b);
            }
            m_inStream.WriteByte((Encoding.ASCII.GetBytes("\n"))[0]);
        }

    }
}
