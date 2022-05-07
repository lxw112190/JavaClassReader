using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JavaClassReader.basicinfo.instruction
{
    public class InstructionTable
    {
        //public static HashMap<Integer, String> mMap;
        public static Dictionary<Int32, String> mMap;

        public static String getInstruction(int bytecode)
        {
            if (mMap == null)
            {
                buildMap();
            }

            if (mMap.Keys.Contains(bytecode))
            {
                return mMap[bytecode];
            }
            else
            {
                return "未知";
            }
          
        }

        public static void buildMap()
        {
            mMap = new Dictionary<Int32, string>();
            try
            {
                using (StreamReader sr = new StreamReader("ins.txt"))
                {
                    string line;
                    int i = 0;
                    Int32 ins = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (i % 2 == 0)
                        {
                            //将读到的string转化为16进制
                            ins = Convert.ToInt32(line, 16);
                        }
                        else if (i % 2 == 1)
                        {
                            mMap.Add(ins, line);
                        }
                        i++;
                    }
                }

            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.Error.Write(e);
            }
            catch (IOException e)
            {
                Console.Error.Write(e);
            }
        }
    }

}
