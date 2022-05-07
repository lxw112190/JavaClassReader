using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JavaClassReader.basictype;

namespace JavaClassReader.constantinfo
{
    public class ConstantClass : ConstantInfo
    {
        public int nameIndex;

        public override void read(FileStream file)
        {
            nameIndex = U2.read(file);
        }
    }
}
