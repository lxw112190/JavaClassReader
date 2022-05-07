using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JavaClassReader.basictype;
using System.IO;

namespace JavaClassReader.basicinfo.attribute
{
    public class ExceptionTable
    {
        public int startPc;
        public int endPc;
        public int handlerPc;
        public int catchType;

        public void read(FileStream file)
        {
            startPc = U2.read(file);
            endPc = U2.read(file);
            handlerPc = U2.read(file);
            catchType = U2.read(file);
            //这里可以增加一个输出输出异常范围的功能
        }
    }
}
