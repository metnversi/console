using System;
using Modbus.Net;
using Modbus.Net.Modbus;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        var modbusMasterTcp = new ModbusMasterTcp("127.0.0.1", 5020);
        var communicator = new ModbusCommunicator(modbusMasterTcp);

        // Read values from the device
        ushort startAddress = 1;
        ushort numRegisters = 5;
        var result = await communicator.GetDatasAsync<AddressUnit>(ModbusDataType.HoldingRegister, startAddress, numRegisters);
    }
}