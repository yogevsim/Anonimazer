import socket
from ClientData import *
from thread import *
import message
import time
import sqlite3



class DB_Hanlder():
    ip = '0.0.0.0'
    port = 5001
    serverSock = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    serverSock.bind((ip,port))
    hash_to_file_dict = {}
    all_clients_sockets_addr_list = []
    addr_to_ClientData_dict = {}

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

    def handle_client_requests(self,client_obj):


          while True:
                data = client_obj.socket.recv(1024)

                report_handler = message.Report_Handler(data)

                db = sqlite3.connect('reports.db')
                cursor = db.cursor()

                sql_command = """
                CREATE TABLE IF NOT EXISTS reports (
                last_node TEXT,
                next_node TEXT,
                time_stamp TEXT,
                data TEXT);
                """
                cursor.execute(sql_command)

                sql_command = """INSERT INTO reports (last_node, next_node, time_stamp, data)
                                VALUES ('%s', '%s', '%s', '%s');""" %(str(report_handler.last_node),str(report_handler.next_node),str(report_handler.timestamp),str(report_handler.data))


                print "sql: "+sql_command
                cursor.execute(sql_command)
                db.commit()
                db.close()



obj = DB_Hanlder()
obj.listen_and_accept()

while 1:
    pass