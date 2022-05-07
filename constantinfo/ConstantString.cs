using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;

namespace JavaClassReader.constantinfo
{
    public class ConstantString : ConstantInfo
    {
        int nameIndex;

        public override void read(FileStream file)
        {
            nameIndex = U2.read(file);
        }
    }

}
