using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;
using JavaClassReader.constantinfo;

namespace JavaClassReader
{
    public class ConstantPool
    {
        public int constant_pool_count;
        public ConstantInfo[] cpInfo;

        public ConstantPool(int count)
        {
            constant_pool_count = count;
            cpInfo = new ConstantInfo[constant_pool_count];
        }

        public void read(FileStream file)
        {
            for (int i = 1; i < constant_pool_count; i++)
            {
                short tag = U1.read(file);
                ConstantInfo constantInfo = ConstantInfo.getConstantInfo(tag);
                constantInfo.read(file);
                cpInfo[i] = constantInfo;
                if (tag == ConstantInfo.CONSTANT_Double || tag == ConstantInfo.CONSTANT_Long)
                {
                    i++;
                }
            }
        }

        public string printConstanPoolInfo(ConstantPool cp)
        {
            StringBuilder info = new StringBuilder();
            if (cp != null)
            {
                info.AppendLine("ConstantPool:" + cp.constant_pool_count);

                for (int i = 1; i < cp.constant_pool_count; i++)
                {
                    ConstantInfo constantInfo = cp.cpInfo[i];
                    if (constantInfo is ConstantMemberRef)
                    {
                        ConstantMemberRef memberRef = (ConstantMemberRef)constantInfo;
                        short tag = memberRef.tag;
                        switch (tag)
                        {
                            case 9:
                                info.AppendLine("#" + i + " fieldref:" + ((ConstantUtf8)cp.cpInfo[memberRef.nameAndTypeIndex]).value);
                                continue;
                            case 10:
                                info.AppendLine("#" + i + " methodref:" + ((ConstantUtf8)cp.cpInfo[memberRef.nameAndTypeIndex]).value);
                                continue;
                            default:
                                continue;
                        }
                    }
                    else if (constantInfo is ConstantNameAndType)
                    {
                        ConstantNameAndType nameAndType_ = (ConstantNameAndType)constantInfo;
                        info.AppendLine("#" + i + " NameAndType        " + ((ConstantUtf8)cp.cpInfo[nameAndType_.nameIndex]).value);
                    }
                    else if (constantInfo is ConstantClass)
                    {
                        ConstantClass clazz = (ConstantClass)constantInfo;
                        info.AppendLine("#" + i + " class        " + ((ConstantUtf8)cp.cpInfo[clazz.nameIndex]).value);
                    }
                    else if (constantInfo is ConstantUtf8)
                    {
                        ConstantUtf8 utf_1 = (ConstantUtf8)constantInfo;
                        info.AppendLine("#" + i + " UTF-8        " + utf_1.value);
                    }
                }
                info.AppendLine("\n");
            }

            return info.ToString();
        }
    }

}
