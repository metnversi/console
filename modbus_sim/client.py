from pymodbus.client import ModbusTcpClient

# Create a Modbus TCP client
client = ModbusTcpClient('localhost', port=5020)

# Connect to the server
client.connect()

# Read holding registers starting from address 0
result = client.read_holding_registers(0, 10)

# Print the results
print(result.registers)

# Close the connection
client.close()