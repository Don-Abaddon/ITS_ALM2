from queries.queries import *

def main():
    piezas = GetAllPiezas()
    for pieza in piezas:
        print(pieza)

if __name__ == "__main__":
    main()
