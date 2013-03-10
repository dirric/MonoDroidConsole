using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmulatedSTDStreams
{
    static public class STDIn
    {
        static MemoryStream m_inStream = new MemoryStream(512);

        public static void WriteLine(string strOut)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(strOut);
            foreach (byte b in bytes)
            {
                m_inStream.WriteByte(b);
            }
            m_inStream.WriteByte((Encoding.ASCII.GetBytes("\n"))[0]);
        }

    }
}
