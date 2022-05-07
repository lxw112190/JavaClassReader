using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;
using JavaClassReader.basicinfo.attribute;

namespace JavaClassReader.basicinfo
{
    public class MemberInfo : BasicInfo
    {
        public int accessFlags;
        public int nameIndex;
        public int descriptorIndex;
        public int attributesCount;
        public AttributeInfo[] attributes;

        public MemberInfo(ConstantPool cp)
            : base(cp)
        {

        }


        public override void read(FileStream file)
        {
            accessFlags = U2.read(file);
            nameIndex = U2.read(file);
            descriptorIndex = U2.read(file);
            attributesCount = U2.read(file);
            attributes = new AttributeInfo[attributesCount];
            for (int i = 0; i < attributesCount; i++)
            {
                AttributeInfo attributeInfo = AttributeInfo.getAttribute(mCp, file);
                attributeInfo.read(file);
                attributes[i] = attributeInfo;
            }
        }
    }
}
