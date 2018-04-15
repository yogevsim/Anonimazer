import socket
from thread import *
import random
from Ceaser import *
from ClientData import Client_Data
import UsersHandlerOld

class Server():
    ip = '0.0.0.0'
    port = 5000

    cs_ip = '127.0.0.1'
    cs_port = 5001
    serverSock = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    serverSock.bind((ip,port))

    cs_serverSock = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    cs_serverSock.bind((cs_ip,cs_port))

    all_clients_sockets_addr_list = []
    addr_to_ClientData_dict = {}
    all_cs_clients = []
    users_handler = UsersHandlerOld.Users()

    def listen_and_accept(self):
        # connect clients and add the to a list.
        while 1:
            print "listening..."
            self.serverSock.listen(5)
            client_sock,client_addr = self.serverSock.accept()
            #print "client details: "+ str(client_addr)
            new_client = Client_Data(client_sock,client_addr)
            print 'Connected with ' + client_addr[0] + ':' + str(client_addr[1])
            self.all_clients_sockets_addr_list.append(new_client)
            self.addr_to_ClientData_dict[str(client_addr)] = new_client
            start_new_thread(self.handle_client_requests, (new_client,))

    def cs_listen_and_accept(self):
        while 1:
            print "cs listening..."
            self.cs_serverSock.listen(5)
            cs_sock, client_addr = self.cs_serverSock.accept()
            print "connected: "+str(client_addr)
            self.all_cs_clients.append(cs_sock)
            start_new_thread(self.handle_cs_requests, (cs_sock,))

    def handle_cs_requests(self,cs_sock):
        while 1:
            request = cs_sock.recv(1024)
            request_list = request.split('~')
            print request_list
            ans = "defult"
           # if request_list[0] == "validate":
           #     ans = self.users_handler.validate_login(request_list)

            #elif request_list[1] == "add":
             #   ans = self.users_handler.add_user([request_list])
            if request_list[0] == 'get all clients':
                ans = self.get_contacts_as_string();
            elif request_list[0] == 'kick':
                self.kick_client(request_list[1],request_list[2])

            print "sending: "+ans
            cs_sock.send(ans)

    def kick_client(self,ip,port):
        for client in self.all_clients_sockets_addr_list:
            if str(client.ip) == ip and str(client.port) == port:
                self.all_clients_sockets_addr_list.remove(client)
                print "kicked: "+client.address
                print "new List: "+str(self.all_clients_sockets_addr_list)

    def get_contacts_as_string(self):

        contacts = ""
        if self.all_clients_sockets_addr_list:
            for client in self.all_clients_sockets_addr_list:
                contacts = contacts + client.ip+','+str(client.port) + '^'
        else:
            contacts = "no nodes"
        return contacts

    def handle_client_requests(self,client_obj):
        target_client = ''
        msg = ''
        answer = ''
        nodes_path = []
        # handle clients' requests and send them the path

        while True:
            data = client_obj.socket.recv(1024)
            print "data: "+data
            if data == 'available':
                print "Server: "+str(client_obj.address)+" is now available."
                client_obj.change_available(True)

            elif data == 'get all clients':
                client_obj.socket.send(self.get_contacts_as_string())

            elif data == 'get random client':
                for client_details in self.all_clients_sockets_addr_list:  # going over all the clients in order to find free nodes
                    client_addr = client_details.address
                    target = client_obj.target_client

                    if client_addr != client_obj.address and client_addr != target and client_details.is_available:  # cheking if the client is not the one sending not the target
                        client_obj.socket.send(client_addr)
                        break


            else:
                target_client = data
                client_obj.target_client = target_client
                nodes_path = self.create_random_path(client_obj)
                answer = '~'.join(nodes_path) +'~'+target_client # bulding the answer to the client's request consisting of the path and message
                print answer
                print "Server: init path:"+ str(answer)
                encrypted_answer = encrypt_path(answer,4)
                print encrypted_answer
                client_obj.socket.send(encrypted_answer)

    def create_random_path(self,client_obj):
        available_nodes_list = []

        for client_details in self.all_clients_sockets_addr_list: # going over all the clients in order to find free nodes
            client_addr = client_details.address
            target = client_obj.target_client

            if client_addr != client_obj.address  and client_addr != target and client_details.is_available: # cheking if the client is not the one sending not the target
                available_nodes_list.append(client_addr)

        random.shuffle(available_nodes_list)
        nodes_path = available_nodes_list[:3]
        print 'busying'
        for addr in nodes_path:
            self.addr_to_ClientData_dict[addr].is_available = False
            print "Server: "+str(addr)+" is now busy"
        print ""
        return nodes_path

server_obj = Server()
start_new_thread(server_obj.cs_listen_and_accept,())

start_new_thread(server_obj.listen_and_accept,())
while 1:
    pass