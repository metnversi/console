from pymodbus.server.sync import ModbusTcpServer, ModbusServerFactory
from pymodbus.datastore import ModbusSequentialDataBlock, ModbusSlaveContext, ModbusServerContext

# Initialize the data store
store = ModbusSlaveContext(
    di=ModbusSequentialDataBlock(0, [17]*100),  # Discrete Inputs Initialize
    co=ModbusSequentialDataBlock(0, [17]*100),  # Coils Initialize
    hr=ModbusSequentialDataBlock(0, [17]*100),  # Holding Registers Initialize
    ir=ModbusSequentialDataBlock(0, [17]*100))  # Input Registers Initialize

context = ModbusServerContext(slaves=store, single=True)

# Create the server
factory = ModbusServerFactory(context)
server = ModbusTcpServer(factory, address=("localhost", 5020))

# Start the server
server.start()