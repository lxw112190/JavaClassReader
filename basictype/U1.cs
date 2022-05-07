using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JavaClassReader.basictype
{
    public class U1
    {
        public static short read(FileStream file)
        {
            byte[] bytes = new byte[1];

            file.Read(bytes, 0, bytes.Length);

            short value = (short)(bytes[0] & 0xFF);
            return value;
        }
    }
}
