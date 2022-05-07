using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JavaClassReader.basicinfo
{
    public abstract class BasicInfo
    {
        protected ConstantPool mCp;

        public BasicInfo(ConstantPool cp)
        {
            mCp = cp;
        }

        public abstract void read(FileStream file);
    }
}
