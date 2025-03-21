import sqlite3

def connectionString():
    db_path = '\\\\prt-itstech\\itstech\\Yamil\\ITS_ALM\\its_alm2.db'
    try:
        conn = sqlite3.connect(db_path)
        return conn
    except sqlite3.Error as e:
        print(f'An error ocurred: {e}')
        return None
    
