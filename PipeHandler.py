import time
import struct
import thread

class PipeHandler():

    def __init__(self,action_pipe_name,data_pipe_name,name):
        self.name = name
        self.try_connect(action_pipe_name,data_pipe_name)
        self.action_list = []
        thread.start_new_thread(self.listen_for_data,())

    def send_data_in_pipe(self,data):
        s = data
        self.send.write(struct.pack('I', len(s)) + s)   # Write str length and str
        print 'Wrote:', s


    def listen_for_data(self):
        # msg RFC: send msg~IP~PORT

        while 1:
                self.recv.seek(0)                               # EDIT: This is also necessary
                n = struct.unpack('I', self.recv.read(4))[0]    # Read str length
                s = self.recv.read(n)                           # Read str
                print 'Read:', s
                print self.name+":"+s
                action_and_params = s.split('~')
                self.action_list.append(action_and_params)

    def try_connect(self,action_pipe_name,data_pipe_name):
        try:
            self.recv = open(r'\\.\pipe\%s'%(action_pipe_name), 'r+b', 0)
            time.sleep(0.5)
            self.send = open(r'\\.\pipe\%s'%(data_pipe_name), 'r+b', 0)
        except Exception, e:
            print self.name+"pipes not yet open trying againg..."
            self.try_connect(action_pipe_name,data_pipe_name)
