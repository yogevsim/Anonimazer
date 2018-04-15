import socket
from thread import *
from datetime import datetime
from Ceaser import *
from message import *
from PipeHandler import *
from hashlib import *




class client():

    def __init__(self,action_pipe_name,data_pipe_name,do_conct_pipe,do_handle_users):
        self.ip = ''
        self.port = 0
        self.client_num = None
        self.client_addr = (self.ip, self.port)
        self.request_sock = None
        self.server_sock = None
        self.report_sock = None
        self.last_node_received = None
        self.action_pipe_name = action_pipe_name
        self.data_pipe_name = data_pipe_name
        self.do_conct_pipe = do_conct_pipe
        self.do_handle_users = do_handle_users
        self.Send_msg_Hndler = Send_Message_Handler()
        self.is_acked = False
        self.hash_to_msg = {}
        self.temp = 0

        if self.do_handle_users == "true":
            import UserHandler
            self.userHandler = UserHandler.user_handler()
            thread.start_new_thread(self.userHandler.listen_and_accept,()
)


    def init_client(self):
        # Initiates all necessary functions.

        self.connect_to_server()
        self.conncet_to_db()
        self.create_server_sock()
        start_new_thread(self.listen_for_data_and_pass,())
        if self.do_handle_users == "true":
            start_new_thread(self.init_users,())
        if self.do_conct_pipe == "true":
            self.pipe_handler = PipeHandler(self.action_pipe_name,self.data_pipe_name,self.client_num)
            start_new_thread(self.handle_action_list,())


    def init_users(self):

        start_new_thread(self.userHandler.listen_and_accept,())
        # request RFC : 'send'~'ip'~port~msg, socket

        while 1:
            if len(self.userHandler.request_list) > 0:
                request = self.userHandler.request_list.pop(0)
                print self.client_num + ": handling request: " + str(request)

                if request:
                    request_list = request[0].split('~')
                    print self.client_num+": handling request: "+str(request_list)
                    user_sock = request[1]

                    ans = self.send_a_message(request_list[3],(request_list[1],int(request_list[2])))
                    if ans == "acked":
                        user_sock.send("acked")


    def conncet_to_db(self):
        client_soc = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        try:

            client_soc.connect(('127.0.0.1',7000))
            self.report_sock = client_soc
            print self.client_num+"- connected to DB."
        except:
            print self.client_num+"DB offline."

    def connect_to_server(self):
        # Connects to the main requests server.

        client_soc = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        client_soc.connect(('localhost',5000))
        self.request_sock = client_soc
        self.client_addr = client_soc.getsockname()
        self.ip = self.client_addr[0]
        self.port = self.client_addr[1]

    def create_server_sock(self):
        # Creates a P2P socket used for transmitting data.

        server_sock = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
        server_sock.bind(self.client_addr)
        self.server_sock = server_sock
        return server_sock

    def request_server_for_path(self,msg,target_addr):
        # Sends a request to the server for a path to the desired client.
        #print self.client_num+str(target_addr)+msg+"1232456"
        encrypted_msg = self.encrypt_message(msg,5)
        self.request_sock.send(target_addr)
        path = self.request_sock.recv(1024)+'~'+encrypted_msg  # The server's answer.
        print self.client_num+path
        return path

    def request_server_for_contacts(self):
        self.request_sock.send("get all clients")
        all_contacts = self.request_sock.recv(1024)
        print(all_contacts)
        return all_contacts

    def encrypt_message(self,msg,num_of_nodes):

        for _ in range(num_of_nodes):
            msg = encrypt_or_decrypt(msg,'1')
        return msg

    def handle_action_list(self):
        while 1:
            if len(self.pipe_handler.action_list) > 0:
                action_list = self.pipe_handler.action_list.pop()
                print self.client_num+str(action_list)
                if action_list[0] == "send msg":
                    print str(tuple((action_list[2],int(action_list[3]))))+"yogevus"
                    self.send_a_message(action_list[1],tuple((action_list[2],int(action_list[3]))))
                elif action_list[0] == "get all clients": # sending the GUI all the contacts.
                    self.send_contacts_in_pipe()
    def send_contacts_in_pipe(self):
        self.pipe_handler.send_data_in_pipe("all contacts~"+self.request_server_for_contacts())


    def listen_for_data_and_pass(self):
        if not self.server_sock:  # the socket for sending and receiving data has not been opened yet.
            self.server_sock = self.create_server_sock()
        while 1:
            pure_data, addr = self.server_sock.recvfrom(1024)
            if not pure_data.split('~')[0] == 'return to sender':
                self.last_node_received = addr
            self.handle_data(pure_data)


    def handle_msg(self,raw_msg):
        print "in handle msg"
        msg_list = raw_msg.split('<>')
        print self.client_num+" msg list: "+str(msg_list)
        if int(msg_list[1]) > 1: # msg is fragmnted
            if msg_list[0] not in self.hash_to_msg.keys(): # new msg
                self.hash_to_msg[msg_list[0]] = Recieved_Message_Handler(raw_msg)

            else:
                msg_obj = self.hash_to_msg[msg_list[0]]
                full_msg = msg_obj.add_fragment(raw_msg)

                if full_msg: # this was the last fragment

                    print self.client_num+"- this is the full msg: "+full_msg
                    self.connect_to_real_target_and_send(full_msg)
                    del self.hash_to_msg[msg_list[0]]
                else: # there are more fragment, sending semi ack
                    self.send_semi_ack()

        else: # msg is not fragmented
            self.connect_to_real_target_and_send(msg_list[3])

    def send_final_ack(self):
     #   print self.client_num + '-',
     #   print("Sending Ack")
     #   print ''

        answer = 'ACK'
        full_ans = "return to sender~" + answer
        self.send_answer(full_ans)

    def connect_to_real_target_and_send(self,msg_and_addr):

        # connecting to actual target
        msg = msg_and_addr.split('<^>')[0]
        next_node = msg_and_addr.split('<^>')[1]
        self.report_to_DB(str(self.last_node_received), "Reciever", msg)

        next_node = next_node.replace("'","").replace('(','').replace(')','')
        next_node = next_node.split(',')
        # print next_node
        next_node_ip = next_node[0]
        next_node_port = int(next_node[1])
        next_node = (next_node_ip, next_node_port)
        print self.client_num+str(next_node)+ "this is the next node"

        try:
            temp_sock = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
            temp_sock.connect(next_node)
            temp_sock.send(msg)
            self.send_final_ack()
            #temp_sock.close()
        except:
            print self.client_num+" can't connect or send to actual target."


    def print_and_ack(self,msg):
        #time.sleep(4)
        print self.client_num + "- you have received a message: " + msg
        if self.do_conct_pipe == "true":
            self.pipe_handler.send_data_in_pipe('new msg~'+msg)


        #self.answer_a_message()

    def check_if_next_node_is_last(self,data_list):
        chain = data_list[-1].split('<>')
        print "checking if last: "+str(chain)
        if len(chain) > 0:
            if sha1(chain[-1]).hexdigest() == chain[0]:
                print "last node is next"
                self.pass_data_list([data_list[0],chain[-1]])
                return "ack"


    def handle_data(self,path):
        # The main processor of the data. Decides whether to return the message , send it or display it.
        # Based on the RFC.

        data_list = path.split('~')
        if not data_list[0] == 'return to sender':  #  This data is not for this clients and need to be passed on.
            data_list = decrypt_one_layer(data_list)  # peels off one layer of encryption.
            #ans = self.check_if_next_node_is_last(data_list) # checks if the next node is the last one in order to send him the clear msg.
            #if ans == "ack":
            #   return ans
        if len(data_list) == 1:  # this is the last node
            self.handle_msg(data_list[0])

        elif data_list[0] == 'return to sender':  # The RFC for when the data needs to be returned or sent.

            if self.last_node_received is None:  # You didn't receive any data thus you initiated it.
                print self.client_num+"- you have received an answer: " + data_list[-1]

                if data_list[-1] == 'ACK':
                    self.userHandler.tcpSock.send("ack")
                    client.temp += 1
                    #time.sleep(1)
                    self.is_acked = True
               # print self.client_num + str(self.is_acked)

                print ''
            else:  # Return the data.
                self.send_answer(path)

        elif len(data_list) > 1:
            self.pass_data_list(data_list)

    def pass_data_list(self,data_list):
        print self.client_num + str(data_list)
        # print data_list
        next_node = data_list.pop(0).replace("'","").replace('(','').replace(')','')
        next_node = next_node.split(',')
        # print next_node
        next_node_ip = next_node[0]
        next_node_port = int(next_node[1])
        next_node = (next_node_ip, next_node_port)
        chain = "~".join(data_list)
        self.send_data_along_chain(next_node, chain)


    def report_to_DB(self,last_node,next_node,chain):

        data = chain.split('~')[-1]

        report = last_node+'~'+str(self.client_addr)+'~'+next_node+'~'+str(datetime.now())+'~'+data
        try:
            self.report_sock.send(report)
        except:
            self.report_sock = None
            self.conncet_to_db()
            if self.report_sock:
                self.report_sock.send(report)
            else:
                print self.client_num+"-No DB available."

    def send_data_along_chain(self,next_node,chain):
        print 'passing'

        if not self.last_node_received:
            self.report_to_DB('Sender', str(next_node), chain)

        else:
            self.report_to_DB(str(self.last_node_received),str(next_node),chain)

        try:
            time.sleep(0.1)
            self.server_sock.sendto(chain,next_node)
            print self.client_num+'- Next Node: '+str(next_node)+' chain: '+chain
        except:
            print self.client_num+ " cant send."
    def get_random_client(self):
        self.request_sock.send('get random client')
        return self.request_sock.recv(1024)

    def send_a_message(self,full_message,target_addr):
        dummy_target_addr = self.get_random_client()

        # addr RFC: ('ip',port)
        full_message = full_message + '<^>' + str(target_addr)
        fragments = self.Send_msg_Hndler.assemble_msg(full_message)

        for message in fragments:
            print ''
            print self.client_num + '- sending: ' + message + ' to: ' + str(dummy_target_addr)
            path = self.request_server_for_path(message,dummy_target_addr)
            print 'Initial path: ' + path
            print ''
            #
            ans = self.handle_data(path)
            if ans == "ack":
                print "returning ack"
                self.send_final_ack()
            time.sleep(0.1)


    def send_semi_ack(self):
        print self.client_num+'-',
        print("Sending Ack")
        print ''

        answer = 'ack'
        full_ans = "return to sender~"+answer
        self.send_answer(full_ans)


    def send_answer(self,full_ans):
        print self.client_num + full_ans

        #print self.client_num+'- returning: '+full_ans.split('~')[1]
        self.server_sock.sendto(full_ans,self.last_node_received)
        self.last_node_received = None
        self.update_server_availability()

    def update_server_availability(self):
        self.request_sock.send('available')

if __name__ == '__main__':
    client_obj = client("a","b","false","false")
    client_obj.client_num = "test_client"
    client_obj.init_client()

    while 1:
        pass






