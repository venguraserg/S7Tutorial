using DAL;
using Model;
using S7.Net;
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
            int period = 60 * 1000;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            Timer timer = new Timer(tm, poolData, 0, period);
            
            bool startSend = false;
            while (true)
            {
                Console.WriteLine($"Передача в бот ->{startSend}");
                var text = Console.ReadLine();
                switch (text)
                {
                    case "start":
                        startSend = true;
                       
                        break;
                    case "stop":
                        startSend = false;
                        break;
                    default:
                        Console.WriteLine("No correct input");
                        break;
                }
                    


            }


           
        }

        

        public static void Count(object obj)
        {
            List<PlcMemoryCelsReal> poolData = (List<PlcMemoryCelsReal>)obj;
            Console.Clear();
            Console.WriteLine(DateTime.Now.ToShortDateString()+"  "+ DateTime.Now.ToShortTimeString());
            for (var i = 0; i < poolData.Count; i++)
            {
                Console.WriteLine($"/*Plc {poolData[i].Ip} DB{poolData[i].Db}.{poolData[i].Adr} */{poolData[i].TextTag} Value -> {PoolPLCSevice.ReadPlcData(poolData[i]):f2}");
            }
            Console.WriteLine("***********************************************************************");

        }



    }


    
}
