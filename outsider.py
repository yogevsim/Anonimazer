import socket
import time
ip = '0.0.0.0'
port = 5005
client_soc = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client_soc.connect(('localhost', port))
i = 0
while 1:
    raw_input("enter!")
    print "sending..."
    time.sleep(1)
    client_soc.send("send~127.0.0.1~6000~this is a very very very very very very very veru very very ry veru very very vry veru very very vry veru very very vry veru very very vry veru very very vry veru very very vvery very very long message.")
    ans = client_soc.recv(1024)
    print ans
    i = i+1