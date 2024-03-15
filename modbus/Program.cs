using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modbus
{
    public class Program
    {
        static void Main(string[] args)
        {
            //modbus tcp server creating and listening in EasyModbusTCP
            EasyModbus.ModbusServer modbusServer = new EasyModbus.ModbusServer();
            modbusServer.Listen();
            Console.WriteLine("Modbus TCP Server is listening");
            Console.ReadKey();
            Console.WriteLine("");
        }
    }
}
