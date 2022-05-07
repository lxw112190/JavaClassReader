using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JavaClassReader.basictype;

namespace JavaClassReader.constantinfo
{
    public class ConstantMethodHandle : ConstantInfo
    {
        public short referenceKind;
        public int referenceIndex;

        public override void read(FileStream file)
        {
            referenceKind = U1.read(file);
            referenceIndex = U2.read(file);
        }
    }
}
