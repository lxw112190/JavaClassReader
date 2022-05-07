using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basicinfo;

namespace JavaClassReader
{
    public class ClassFile
    {
        public long magic;
        public int minorVersion;
        public int majorVersion;
        public ConstantPool constantPool;
        public int accessFlag;
        public String className;
        public String superClass;
        public int interfaceCount;
        public String[] interfaces;
        public int fieldCount;
        public MemberInfo[] fields;
        public int methodCount;
        public MemberInfo[] methods;
    }
}
