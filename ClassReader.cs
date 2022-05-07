using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using JavaClassReader.basictype;
using JavaClassReader.constantinfo;
using JavaClassReader.basicinfo;
using JavaClassReader.basicinfo.instruction;
using JavaClassReader.basicinfo.attribute;

namespace JavaClassReader
{
    public class ClassReader
    {
        public static string read(String classPath)
        {
            StringBuilder info = new StringBuilder();
            FileStream file = new FileStream(classPath, FileMode.Open, FileAccess.Read);
            try
            {
                ClassFile classFile = new ClassFile();
                classFile.magic = U4.read(file);
                classFile.minorVersion = U2.read(file);
                classFile.majorVersion = U2.read(file);

                //解析常量池
                int constant_pool_count = U2.read(file);
                ConstantPool constantPool = new ConstantPool(constant_pool_count);
                constantPool.read(file);

                //获取常量池信息
                string cpInfo = constantPool.printConstanPoolInfo(constantPool);
                info.Append(cpInfo);

                //获取类信息
                classFile.accessFlag = U2.read(file);
                int classIndex = U2.read(file);
                ConstantClass clazz = (ConstantClass)constantPool.cpInfo[classIndex];  //获取类名，并将其转化为ContantClass类
                ConstantUtf8 className = (ConstantUtf8)constantPool.cpInfo[clazz.nameIndex];
                classFile.className = className.value;
                info.Append("classname:" + classFile.className + "\n");

                //获取父类信息
                int superIndex = U2.read(file);
                ConstantClass superClazz = (ConstantClass)constantPool.cpInfo[superIndex];
                ConstantUtf8 superclassName = (ConstantUtf8)constantPool.cpInfo[superClazz.nameIndex];
                classFile.superClass = superclassName.value;
                info.Append("superclass:" + classFile.superClass + "\n");

                //获取接口信息
                classFile.interfaceCount = U2.read(file);
                classFile.interfaces = new String[classFile.interfaceCount];
                for (int i = 0; i < classFile.interfaceCount; i++)
                {
                    int interfaceIndex = U2.read(file);
                    ConstantClass interfaceClazz = (ConstantClass)constantPool.cpInfo[interfaceIndex];
                    ConstantUtf8 interfaceName = (ConstantUtf8)constantPool.cpInfo[interfaceClazz.nameIndex];
                    classFile.interfaces[i] = interfaceName.value;
                    info.Append("interface:" + interfaceName.value + "\n");
                }
                info.Append("\n");

                //获取字段信息
                classFile.fieldCount = U2.read(file);
                classFile.fields = new MemberInfo[classFile.fieldCount];
                for (int i = 0; i < classFile.fieldCount; i++)
                {
                    MemberInfo fieldInfo = new MemberInfo(constantPool);
                    fieldInfo.read(file);
                    info.Append("field:" + ((ConstantUtf8)constantPool.cpInfo[fieldInfo.nameIndex]).value + ", ");
                    info.Append("desc:" + ((ConstantUtf8)constantPool.cpInfo[fieldInfo.descriptorIndex]).value + "\n");
                }
                info.Append("\n");

                //获取方法信息
                classFile.methodCount = U2.read(file);
                classFile.methods = new MemberInfo[classFile.methodCount];
                for (int i = 0; i < classFile.methodCount; i++)
                {
                    MemberInfo methodInfo = new MemberInfo(constantPool);
                    methodInfo.read(file);
                    info.Append("method:" + ((ConstantUtf8)constantPool.cpInfo[methodInfo.nameIndex]).value + "(), ");
                    info.Append("desc:" + ((ConstantUtf8)constantPool.cpInfo[methodInfo.descriptorIndex]).value + "\n");
                    for (int j = 0; j < methodInfo.attributesCount; j++)
                    {
                        if (methodInfo.attributes[j] is CodeAttribute)
                        {
                            CodeAttribute codeAttribute = (CodeAttribute)methodInfo.attributes[j];
                            for (int m = 0; m < codeAttribute.codeLength; m++)
                            {
                                short code = codeAttribute.code[m];
                                info.Append(InstructionTable.getInstruction(code) + "\n");
                            }
                        }
                    }
                    info.Append("\n");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Error.WriteLine(e);
            }
            return info.ToString();
        }

    }

}
