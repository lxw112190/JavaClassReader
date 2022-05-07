using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JavaClassReader.basictype
{
    public class U2
    {
        public static int read(FileStream file)
        {

            //bytes作为缓冲数组存储两个字节
            //class文件中字符以U-16编码
            byte[] bytes = new byte[2];

            file.Read(bytes, 0, bytes.Length);

            //将缓冲数组中的两个字节解析成字符。
            int num = 0;
            for (int i = 0; i < bytes.Length; i++)
            {

                num <<= 8;   //num=num*2^8,左位移表示乘，右位移表示/,>>>表示无符号右移
                num |= (bytes[i] & 0xff);   // | 表示按位或运算    &表示按位与运算   
            }
            return num;
        }
    }
}
