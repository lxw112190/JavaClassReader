using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JavaClassReader.basictype;

namespace JavaClassReader.constantinfo
{
    public class ConstantMethodType : ConstantInfo
    {
        int descType;

        public override void read(FileStream file)
        {
            descType = U2.read(file);
        }
    }
}
