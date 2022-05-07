using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;
using JavaClassReader.constantinfo;

namespace JavaClassReader.basicinfo.attribute
{
    public class AttributeInfo : BasicInfo {
    public int nameIndex;
    public int length;
    public short[] info;

    public  const String CODE = "Code";

    public AttributeInfo(ConstantPool cp, int nameIndex):  base(cp)
    {
        this.nameIndex = nameIndex;
    }

    public override void read(FileStream file)
    {
        length = (int)U4.read(file);
        info = new short[length];
        for (int i = 0; i < length; i++) {
            info[i] = U1.read(file);
        }
    }

    public static AttributeInfo getAttribute(ConstantPool cp, FileStream file)
    {
        int nameIndex = U2.read(file);
        String name = ((ConstantUtf8) cp.cpInfo[nameIndex]).value;
        switch (name) {
            case CODE:
                return new CodeAttribute(cp, nameIndex);
        }
        return new AttributeInfo(cp, nameIndex);

    }
}
}
