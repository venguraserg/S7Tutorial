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
            
            string path = "test.txt";
            var info = File.ReadAllLines(path);
            char[] charSeparators = new char[] { ' ' };
            PlcDataAddress[] poolData = new PlcDataAddress[info.Length];
            
            for (var i = 0; i < info.Length; i++)
            {
                var o = info[i].Split(charSeparators);
                
                poolData[i] = new PlcDataAddress
                {
                    Ip = o[0],
                    Db = int.Parse(o[1]),
                    Adr = int.Parse(o[2])
                };
                
                    
            
            }

            Console.WriteLine("Читаем данные из:");

            foreach (var item in poolData)
            {
                Console.WriteLine(item.ToString());
            }

            while (true)
            {
                //PlcDataAddress value_1 = new PlcDataAddress();
                //Console.Write("Введите IP PLC 192.168.3.");
                //value_1.Ip = "192.168.3."+Console.ReadLine();
                //Console.Write("\nВведите номер DB");
                //value_1.Db = int.Parse(Console.ReadLine());
                //Console.Write($"\nВведите адрес в DB{value_1.Db}.");
                //value_1.Adr = int.Parse(Console.ReadLine());
                //Console.WriteLine("\n***************************************");

                //File.Write("test.txt", $"IP - > {value_1._ip}, DB{value_1._db}.{value_1._adr}")
                //Console.WriteLine($"IP - > {value_1._ip}, DB{value_1._db}.{value_1._adr}");

                for(var i = 0; i < poolData.Length; i++)
                {
                    Console.WriteLine($"Plc {poolData[i].Ip} DB{poolData[i].Db}.{poolData[i].Adr}  Value -> {ReadPlcData(poolData[i]):f2}");
                }

                

                //Console.WriteLine("Для продолжения нажмите любую кнопку....");
                //Console.ReadKey();

                Thread.Sleep(5000);
                

            }
           
        }

        private static double ReadPlcData(PlcDataAddress data)
        {
            using (var plc = new Plc(CpuType.S71200, ip: data.Ip, 0, 0))
            {
                plc.Open();
                //Console.WriteLine($"CPU: {plc.CPU} ip adress -> {plc.IP} connected is {plc.IsConnected}, Max PDU Size {plc.MaxPDUSize} TimeOut -> {plc.ReadTimeout}");
                var result = (float)plc.Read(DataType.DataBlock, data.Db, data.Adr, VarType.Real,1);
                //Console.WriteLine($"value -> {result}");
                
                plc.Close();

                return (double)result;
            }
        }


        
    }


    
}
