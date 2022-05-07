using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JavaClassReader.constantinfo;

namespace JavaClassReader
{
    public abstract class ConstantInfo {
    public  const short CONSTANT_Class = 7;
    public  const short CONSTANT_Fieldref = 9;
    public  const short CONSTANT_Methodref = 10;
    public  const short CONSTANT_InterfaceMethodref = 11;
    public  const short CONSTANT_String = 8;
    public  const short CONSTANT_Integer = 3;
    public  const short CONSTANT_Float = 4;
    public  const short CONSTANT_Long = 5;
    public  const short CONSTANT_Double = 6;
    public  const short CONSTANT_NameAndType = 12;
    public  const short CONSTANT_Utf8 = 1;
    public  const short CONSTANT_MethodHandle = 15;
    public  const short CONSTANT_MethodType = 16;
    public  const short CONSTANT_InvokeDynamic = 18;

    public short tag;

    public abstract void read(FileStream file);

    public static ConstantInfo getConstantInfo(short tag) {
        switch (tag) {
            case CONSTANT_Class:
               return new ConstantClass();   
            case CONSTANT_Fieldref:
            case CONSTANT_Methodref:
            case CONSTANT_InterfaceMethodref:
                return new ConstantMemberRef();
            case CONSTANT_Long:
                return new ConstantLong();
            case CONSTANT_Double:
                return new ConstantDouble();
            case CONSTANT_String:
                return new ConstantString();
            case CONSTANT_Integer:
                return new ConstantInteger();
            case CONSTANT_Float:
                return new ConstantFloat();
            case CONSTANT_NameAndType:
                return new ConstantNameAndType();
            case CONSTANT_Utf8:
                return new ConstantUtf8();
            case CONSTANT_MethodHandle:
                return new ConstantMethodHandle();
            case CONSTANT_MethodType:
                return new ConstantMethodType();
            case CONSTANT_InvokeDynamic:
                return new ConstantInvokeDynamic();
                //这里是不是有个缺陷？？
        }
        return null;
    }

}

}
