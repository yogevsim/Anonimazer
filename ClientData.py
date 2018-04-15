
class Client_Data():

    is_available = None
    ip = ''
    port = None
    socket = None
    address = None
    target_client = None

    def __init__(self,socket,address):
        self.is_available = True
        self.socket = socket
        self.address = str(address)
        self.ip = address[0]
        self.port = address[1]

    def change_available(self,ToF):
        self.is_available = ToF


