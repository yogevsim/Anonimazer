import socket
import thread
ip = '127.0.0.1'
port = 6000

server_sock = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
server_sock.bind((ip,port))

def listen_for_data(socket):
        data = socket.recv(1024)
        print data

while 1:
    print "listening..."
    server_sock.listen(5)
    socket,addr = server_sock.accept()
    print "connected: "+str(addr)

    thread.start_new_thread(listen_for_data,(socket,))

