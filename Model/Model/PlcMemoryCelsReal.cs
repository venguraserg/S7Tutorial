


using S7.Net;

namespace Model
{
    public class PlcMemoryCelsReal
    {
        public CpuType Cpu { get; set; }
        public string Ip { get; set; }
        public int Db { get; set; }
        public int Adr { get; set; }
        public string TextTag { get; set; }
        public PlcMemoryCelsReal(CpuType cpuType,string ip, int db, int adr,string textTag)
        {
            Cpu = cpuType;
            Ip = ip;
            Db = db;
            Adr = adr;
            TextTag = textTag;
        }
         public PlcMemoryCelsReal(CpuType cpuType, string ip, int db, int adr) : this(cpuType, ip, db, adr, string.Empty)
        {

        }
        
        public override string ToString()
        {
            return $"PLC IP {Ip} DB{Db}.{Adr}";
        }
        

    }
}
