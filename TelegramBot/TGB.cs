using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot
{


    static public class TGB
    {
        static public void TelegramBot(string text)
        {
            string SendMessage = "https://api.telegram.org/bot1638062702:AAFw09mf-K_PnvgXXreGzqYHSfCfTprjEyU/sendmessage?chat_id=-516859116&text=" + DateTime.Now.ToString()+"\n"+text;
            using (var webClient = new WebClient())
            {
                string JSONwithAdd = webClient.DownloadString(SendMessage);
            }
        }
    }
        
}
