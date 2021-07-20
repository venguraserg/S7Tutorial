using S7.Net;
using S7Tutorial.DataAccesLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace S7Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            



            var poolData = PoolPLCSevice.GetPoolData();

            

            Console.WriteLine("Читаем данные из:");

            foreach (var item in poolData)
            {
                Console.WriteLine(item.ToString());
            }

            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            Timer timer = new Timer(tm, poolData, 0, 2000);
            while (true)
            {
                
                
                
                
            }


           
        }

        private static double ReadPlcData(PlcMemoryCelsReal data)
        {
            using (var plc = new Plc(data.Cpu, data.Ip, 0, 0))
            {
                plc.Open();
                var result = (float)plc.Read(DataType.DataBlock, data.Db, data.Adr, VarType.Real,1);
                plc.Close();

                return (double)result;
                
            }
        }

        public static void Count(object obj)
        {
            List<PlcMemoryCelsReal> poolData = (List<PlcMemoryCelsReal>)obj;

            for (var i = 0; i < poolData.Count; i++)
            {
                Console.WriteLine($"Plc {poolData[i].Ip} DB{poolData[i].Db}.{poolData[i].Adr} {poolData[i].TextTag} Value -> {ReadPlcData(poolData[i]):f2}");
            }
            Console.WriteLine("***********************************************************************");

        }



    }


    
}
