def getTranslatedMessage(mode, message, key):
     if mode[0] == 'd':
         key = -key
     translated = ''

     for symbol in message:
         if symbol.isalpha():
             num = ord(symbol)
             num += key

             if symbol.isupper():
                 if num > ord('Z'):
                     num -= 26
                 elif num < ord('A'):
                     num += 26
             elif symbol.islower():
                 if num > ord('z'):
                     num -= 26
                 elif num < ord('a'):
                     num += 26

             translated += chr(num)
         elif symbol.isdigit():
             translated += str(int(symbol)+key)
         else:
             translated += symbol
     return translated




def encrypt_or_decrypt(message,choice):

    result = ''

    if choice == '1':

        for i in range(0, len(message)):
            result = result + chr(ord(message[i]) - 2)
    elif choice == '2':

        for i in range(0, len(message)):
            result = result + chr(ord(message[i]) + 2)

    return  result

def encrypt_path(path,num_of_nodes):
    node = ''
    encrypted_list = []
    list_of_nodes = path.split('~')
    for i in range(num_of_nodes):
        node = list_of_nodes[i]
        for j in range(i+1):
            node = encrypt_or_decrypt(node,'1')

        encrypted_list.append(node)
    encrypted_path = '~'.join(encrypted_list)
    return encrypted_path

def decrypt_one_layer(path):
    encrypted_list = path
    decrypted_list = []
    for node in encrypted_list:
        decrypted_list.append(encrypt_or_decrypt(node,'2'))
    return decrypted_list

# x = encrypt_path("('127.0.0.1', 1536)~('127.0.0.1', 1566)~('127.0.0.1', 1530)~('127.0.0.1', 1542)~mn",5)
# print('encrypted list: '+str(x))
# print "dec path: " +str(decrypt_one_layer(x.split('~')))




