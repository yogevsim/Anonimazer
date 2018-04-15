import hashlib

class Send_Message_Handler():


    def assemble_msg(self,raw_data):
        '''
        Assmbels the raw data according to the RFC.

        RFC: SHA1(raw data) <> num of fragments <> serial number <> data
        '''
        full_fragments_list = []
        hashed_msg = hashlib.sha1(raw_data).hexdigest()
        fragments = self.fragment_data(raw_data)

        for i in range(len(fragments)):
            fragment = hashed_msg+'<>'+str(len(fragments))+'<>'+str(i)+'<>'+fragments[i]
            full_fragments_list.append(fragment)

        return full_fragments_list

    def fragment_data(self,raw_data):
        fragments_len = 100
        fragments = [raw_data[i:i+fragments_len] for i in range(0, len(raw_data), fragments_len)]
        print fragments
        return fragments

class Recieved_Message_Handler():

    fragments = []
    num_of_fragments = 0
    fragments_recivied = 0

    def __init__(self,fragment):
        data_list = fragment.split('<>')
        self.num_of_fragments = int(data_list[1])

        self.fragments = [i for i in range(self.num_of_fragments)]
        self.add_fragment(fragment)

    def add_fragment(self,fragment):
        data_list = fragment.split('<>')

        self.fragments[int(data_list[2])] = data_list[3]
        self.fragments_recivied +=1

        if self.fragments_recivied == self.num_of_fragments:

            return "".join(self.fragments)


class Fragment_Handler():

    hash = ''
    data = ''
    total_frags = 0
    index = 0

    def __init__(self,msg):
        data_list = msg.split('<>')

        self.hash = data_list[0]
        self.total_frags = int(data_list[1])
        self.index = data_list[2]
        self.data = data_list[3]


class Report_Handler():

    # report RFC:  last node ~ next node ~ time stamp ~ data ~ is new
    last_node = 'n/a'
    next_node = ''
    timestamp = 0
    data = ''
    is_new = False

    def __init__(self,report):
        data_list = report.split('~')
        print "msg 123: "+str(data_list)
        print "msg: "+str(data_list)
        self.last_node = str(data_list[0]).replace("'" , '')
        self.next_node = str(data_list[1]).replace("'" , '')
        self.timestamp = data_list[2]
        self.data = data_list[3]
        self.is_new = int(data_list[4])


