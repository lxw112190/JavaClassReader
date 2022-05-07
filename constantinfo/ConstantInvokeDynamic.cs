using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;

namespace JavaClassReader.constantinfo
{
    public class ConstantInvokeDynamic : ConstantInfo
    {
        public int bootstrapMethodAttrIndex;
        public int nameAndTypeIndex;

        public override void read(FileStream file)
        {
            bootstrapMethodAttrIndex = U2.read(file);
            nameAndTypeIndex = U2.read(file);
        }
    }

}
