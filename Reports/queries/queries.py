from connection import connect

def GetAllPiezas():
    conn = connect.connectionString()
    if conn:
        try:
            cursor = conn.cursor()
            query = """SELECT 
                            p.PiezaID,
                            m.Nombre as Marca,
                            p.Modelo,
                            p.BarCode,
                            p.Descripcion,
                            c.Category as Categoria, 
                            p.Cantidad 
                            FROM Piezas AS p 
                        INNER JOIN Marcas AS m ON p.Marca = m.ID 
                        INNER JOIN Category As c ON p.Categoria = c.ID;"""
            cursor.execute(query)
            rows =  cursor.fetchall()
            return rows

            cursor.close()
            conn.close()

        except Exception as e:
            print(f'An error ocurred: {e}')
    else:
        print("No se pudo establecer la conexión con la base de datos.")
        return []