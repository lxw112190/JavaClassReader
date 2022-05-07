using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;

namespace JavaClassReader.basicinfo.attribute
{
    public class CodeAttribute : AttributeInfo
    {
        public int maxStack;
        public int maxLocals;
        public int codeLength;
        public short[] code;
        public int excepetionTableLength;
        public ExceptionTable[] exceptionTable;
        public int attributes_count;
        public AttributeInfo[] attributes;


        public CodeAttribute(ConstantPool cp, int nameIndex)
            : base(cp, nameIndex)
        {

        }

        public override void read(FileStream file)
        {
            length = (int)U4.read(file);

            //这里可以增加一个输出maxStack、maxLocal的功能
            maxStack = U2.read(file);
            maxLocals = U2.read(file);
            codeLength = (int)U4.read(file);
            code = new short[codeLength];
            for (int i = 0; i < codeLength; i++)
            {
                code[i] = U1.read(file);
            }
            excepetionTableLength = U2.read(file);
            exceptionTable = new ExceptionTable[excepetionTableLength];
            for (int i = 0; i < excepetionTableLength; i++)
            {
                ExceptionTable exceTable = new ExceptionTable();
                exceTable.read(file);
                exceptionTable[i] = exceTable;
            }
            attributes_count = U2.read(file);
            attributes = new AttributeInfo[attributes_count];
            for (int i = 0; i < attributes_count; i++)
            {
                AttributeInfo attr = AttributeInfo.getAttribute(mCp, file);
                attr.read(file);
                attributes[i] = attr;
            }

        }
    }
}
