using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JavaClassReader.basictype;

namespace JavaClassReader.constantinfo
{
    public class ConstantDouble : ConstantInfo
    {
        public long highValue;
        public long lowValue;

        public override void read(FileStream file)
        {
            highValue = U4.read(file);
            lowValue = U4.read(file);
        }
    }

}
