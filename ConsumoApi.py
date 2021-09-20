import requests
import urllib
import json


def main():
    while True:
        print("\nChoose service you want to use : ")
        print("""
        1 : Login 
        2 : Register
        3 : Verificar Datos
        4 : Lista Usuarios
        0 : Salir"""
              )
        choice = input("\nElige una opcion : ")
        
        if choice == '1':
            print("-------LOGIN-------")
            r = requests.get("https://localhost:5001/api/login")
            data = {  "Usuario": "88",  "Password": "12345"}
            headers =  {"Content-Type":"application/json"}
            response = requests.post(r, json=data, headers=headers)
            response.json()
            if r.status_code == 200:
                print(r.text)
            print("-------LOGIN-------")
        elif choice == '2' :
            print("-------REGISTER-------")
            r = requests.get("https://localhost:5001/api/register")
            data = {  "Usuario": "8",  "Email": "hardware2.21@hotmail.com",  "Nombre": "Ignacio",  "Apellido": "Silva",  "Password": "333"}
            headers =  {"Content-Type":"application/json"}
            response = requests.post(r, json=data, headers=headers)
            response.json()
            if r.status_code == 200:
                print(r.text)
            print("-------REGISTER-------")
        elif choice == '3' :
            print("-------USUARIO-------")
            r = requests.get("https://localhost:5001/api/data/2")
            # Imprimimos el resultado si el código de estado HTTP es 200 (OK):
            if r.status_code == 200:
                print(r.text)
            print("-------USUARIO-------")
        elif choice == '4' :
            print("-------LISTA-------")
            r = requests.get("https://localhost:5001/api/lista")
            # Imprimimos el resultado si el código de estado HTTP es 200 (OK):
            if r.status_code == 200:
                print(r.text)
            print("-------LISTA-------")
        elif choice == '0':
            exit()

if __name__ == "__main__":
    main()