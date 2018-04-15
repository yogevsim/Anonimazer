import sqlite3

class Users():

    def __init__(self):
        db = sqlite3.connect('users.db')
        cursor = db.cursor()

        sql_command = """
                        CREATE TABLE IF NOT EXISTS users (
                        user_name TEXT,
                        password TEXT,
                        name TEXT,
                        contacts TEXT);
                        """
        cursor.execute(sql_command)
        db.close()

       # print "sql: " + sql_command

    def validate_login(self,data_list):
        db = sqlite3.connect('users.db')
        cursor = db.cursor()
        print "data list: "+str(data_list)
        username = data_list[1]
        password = data_list[2]

        cursor.execute("SELECT * FROM users WHERE user_name=?",(username,))

        rows = cursor.fetchall()
        db.close()
        if rows:
            if rows[0][1] == password:
                print rows[0]
                return str(rows)
        return 'false'


    def add_user(self,data_list):
        db = sqlite3.connect('users.db')
        cursor = db.cursor()

        username = data_list[1]
        password = data_list[2]
        name = data_list[3]
        contacts = data_list[4]

        cursor.execute("SELECT * FROM users WHERE user_name=?", (username,))

        rows = cursor.fetchall()

        if rows:
            return 'taken'
        else:
            sql_command = """INSERT INTO users (user_name, password, name, contacts)
                                        VALUES ('%s', '%s', '%s', '%s');"""%(username,password,name,contacts)

            cursor.execute(sql_command)
            db.commit()
            db.close()
            return 'added'

if __name__ == '__main__':
    u = Users()
    u.add_user(['yogevsim','love1234','yogev','a~b~c~d'])
    u.add_user(['a','s','Alon','a~b~c~d'])

    u.validate_login(['a','yogevsim','love1234'])