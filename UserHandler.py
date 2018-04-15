import socket
from thread import *

class user_handler():
    # this class takes care of users outside yhe system who wishes to use it's services.

    ip = '0.0.0.0'
    port = 5005

    serverSock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    serverSock.bind((ip, port))

    tcpSock = None
    tcpAddr = None
    request_list = []

    def listen_and_accept(self):
        # connect clients and add the to a list.
        while 1:
            print "listening..."
            self.serverSock.listen(5)
            client_sock,client_addr = self.serverSock.accept()
            self.tcpSock = client_sock
            self.tcpAddr = client_addr
            print 'Connected with ' + client_addr[0] + ':' + str(client_addr[1])
            start_new_thread(self.handle_client_requests, (client_sock,))


    def handle_client_requests(self,client_sock):
        try:
            while 1:

                # request RFC: request~ip~port~msg
                data = client_sock.recv(1024)
                print "recieved: "+data
                data_list = data.split('~')

                if data_list[0] == "send":
                    print "appending"
                    self.request_list.append((data,client_sock))
        except:
            print "user: "+str(self.tcpAddr)+" closed."

