﻿using DAL;
using System;
using System.Threading;



namespace S7Tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int period = 60 * 1000;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(BatchMethod);
            // создаем таймер
            Timer timer = new Timer(tm, "", 0, period);
            
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

        

        public static void BatchMethod(object obj)
        {
            Console.WriteLine(PoolPLCSevice.GetAllData()); 
        }



    }


    
}
