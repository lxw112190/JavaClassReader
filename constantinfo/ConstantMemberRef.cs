using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;

namespace JavaClassReader.constantinfo
{
    public class ConstantMemberRef : ConstantInfo
    {
        public int classIndex;
        public int nameAndTypeIndex;

        public override void read(FileStream file)
        {
            classIndex = U2.read(file);
            nameAndTypeIndex = U2.read(file);
        }
    }

}
