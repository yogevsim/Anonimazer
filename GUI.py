from Tkinter import *
import time
import thread

class GUI_handler():
    root = Tk()
    root.title("Anonimaizer ")
    root.geometry("300x200")
    root["background"] = "#C4DFE6"

    client = None
    msg_entry = None
    send_btn = None
    target_addr = None

    def __init__(self,client,target_addr):
        self.client = client
        self.target_addr = target_addr

    def init_wehigts_widgets(self):
        for i in range(5):
            self.root.columnconfigure(i, weight=1)
            self.root.rowconfigure(i, weight=1)

        self.msg_entry = Entry(self.root)
        self.msg_entry.grid(row=4, column=1, columnspan=2, sticky=E + W + S + N)

        self.send_btn = Button(self.root,text="send",bg="#07575B",command= self.send_a_msg_from_client)
        self.send_btn.grid(row=4, column=4, sticky=E + W + S + N, columnspan=1)

        self.recieved_label = Label(self.root,background='#C4DFE6')
        self.recieved_label.grid(row=3, column=4)
        self.root.mainloop()

    def send_a_msg_from_client(self):
        self.client.send_a_message(self.msg_entry.get(), self.target_addr)
        thread.start_new_thread(self.wait_for_ack,())
        self.update_label('sent')
        self.root.mainloop()

    def update_label(self,text):
        self.recieved_label.config(text=text)

    def wait_for_ack(self):
        while not self.client.is_acked:
            time.sleep(0.1)

        self.update_label('received')
        #time.sleep(1)
        self.client.is_acked = False
        time.sleep(3)
        self.update_label('')

