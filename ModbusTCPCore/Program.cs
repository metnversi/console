using EasyModbus;
using System.Text;

namespace ModbusTCPCore
{
    public class Program
    {
        static void Main(string[] args)
        {
            ModbusServer modbusServer = new ModbusServer();
            modbusServer.Port = 502;
            modbusServer.Listen();
            Console.WriteLine("Modbus TCP Server is listening");

            // Subscribe to the HoldingRegistersChanged event
            modbusServer.HoldingRegistersChanged += (address, value) =>
            {
                Console.WriteLine($"Server received value {value} at address {address}");
            };

            ModbusClient modbusClient = new ModbusClient("127.0.0.1", 502);
            modbusClient.Connect();
            int a = 40;
            int b = 50;

            if (modbusClient.Connected)
            {
                Console.WriteLine("Modbus TCP Client is connected to the server");

                // Convert a and b to an array of integers
                int[] values = new int[] { a, b };

                // Write the values to the server
                modbusClient.WriteMultipleRegisters(0, values);

                Console.WriteLine("Values sent to the server");
            }
            else
            {
                Console.WriteLine("Modbus TCP Client failed to connect to the server");
            }

            modbusClient.Disconnect();
            // Keep the program running until the user presses 'q'
            System.Console.WriteLine("Press 'q' to quit the program");
            while (Console.ReadKey().Key != ConsoleKey.Q)
            {
                // Do nothing, just wait for the user to press 'q'
            }

            modbusServer.StopListening();
        }
    }
}
