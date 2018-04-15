import socket
from Client import client
import time
import thread
from GUI import GUI_handler


clients_list = []
num_of_nodes = 19

def get_open_port():
        import socket
        s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        s.bind(("",0))
        s.listen(1)
        port = s.getsockname()[1]
        s.close()
        return port

for i in range(num_of_nodes):

    client_obj = client("action"+str(i),"data"+str(i),"false","false")
    client_obj.client_num = str(i+1)
    client_obj.init_client()
    clients_list.append(client_obj)

time.sleep(1)

client_obj = client("actionPipe","dataPipe","false","true")
client_obj.client_num = "yogevi"
client_obj.init_client()
clients_list.append(client_obj)



client.temp = 0
for i in range(1):
    sender = clients_list[0]
    target = clients_list[1]

   # sender.send_a_message('hi how are you??????? my name is yogev what is youer name',target.client_addr)
print 'num of susses: '+str(client.temp)

while 1:
    sender.send_a_message(raw_input("enter a msg: "),target.client_addr)
    print str(target.client_addr)+"yogevi"
    time.sleep(5)
    pass

