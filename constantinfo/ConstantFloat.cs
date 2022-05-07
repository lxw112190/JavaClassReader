using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;

namespace JavaClassReader.constantinfo
{
    public class ConstantFloat : ConstantInfo
    {
        public long value;

        public override void read(FileStream file)
        {
            value = U4.read(file);
        }
    }

}
