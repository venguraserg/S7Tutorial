using S7.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7Tutorial.DataAccesLayer
{
    static public class PoolPLCSevice
    {
        static public List<PlcMemoryCelsReal> GetPoolData() 
        {
            
            var fileText = File.ReadAllLines("test.txt");
            char[] charSeparators = new char[] { ' ' };
            List<PlcMemoryCelsReal> poolData = new List<PlcMemoryCelsReal>();
            for (var i = 0; i < fileText.Length; i++)
            {
                var item = fileText[i].Split(charSeparators);
               CpuType cpu = (CpuType)int.Parse(item[0]);
                var Data = new PlcMemoryCelsReal(cpu, item[1], int.Parse(item[2]), int.Parse(item[3]), item[4]);
                poolData.Add(Data);

            }


            return poolData;
        } 
    }
}
