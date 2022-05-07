using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JavaClassReader.basictype
{
    public class U4
    {
        public static long read(FileStream file)
        {
            byte[] bytes = new byte[4];

            file.Read(bytes, 0, bytes.Length);

            long num = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                num <<= 8;
                num |= (bytes[i] & 0xff);
            }
            return num;
        }
    }
}
