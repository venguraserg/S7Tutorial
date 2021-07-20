
using Model;
using S7.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static public class PoolPLCSevice
    {
        static private List<PlcMemoryCelsReal> GetPoolData()
        {

            var fileText = File.ReadAllLines("PLCMemorycels.txt");
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
        private static double ReadPlcData(PlcMemoryCelsReal data)
        {
            using (var plc = new Plc(data.Cpu, data.Ip, 0, 0))
            {
                plc.Open();
                var result = (float)plc.Read(DataType.DataBlock, data.Db, data.Adr, VarType.Real, 1);
                plc.Close();

                return (double)result;

            }
        }
        public static string GetAllData() 
        {
            var poolData = GetPoolData();
            string data = string.Empty;
            for (var i = 0; i < poolData.Count; i++)
            {
                data += $" * {poolData[i].TextTag} -> {ReadPlcData(poolData[i]):f2}\n";
            }


            return data;
        }
    }
}
