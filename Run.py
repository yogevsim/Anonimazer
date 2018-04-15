import threading


def run_mainServer():
    import MainServer
def run_DBHandler():
    import DBHandler
def run_test():
    import test

threading._start_new_thread(run_mainServer,())
threading._start_new_thread(run_DBHandler,())
threading._start_new_thread(run_test,())