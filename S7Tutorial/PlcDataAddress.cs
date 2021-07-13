using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S7Tutorial
{
    public class PlcDataAddress
    {
        public string Ip { get; set; }
        public int Db { get; set; }
        public int Adr { get; set; }
        public override string ToString()
        {
            return $"PLC IP {Ip} DB{Db}.{Adr}";
        }

    }
}
