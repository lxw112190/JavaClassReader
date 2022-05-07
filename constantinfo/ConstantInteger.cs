using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JavaClassReader.basictype;

namespace JavaClassReader.constantinfo
{
    public class ConstantInteger : ConstantInfo
    {
        public long value;

        public override void read(FileStream file)
        {
            value = U4.read(file);
        }
    }

}
