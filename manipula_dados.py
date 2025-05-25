import pyodbc
import pandas as pd
from datetime import datetime
# Dados de conexão (substituir com suas credenciais) no caso estão com as que eu sei em meu servidor
server = 'localhost'
database = 'testecaua'
username = 'CAUA\\cauar'

# Conectar ao SQL Server usando a biblioteca pyodbc
connect = pyodbc.connect('DRIVER={ODBC Driver 17 for SQL Server};'f'SERVER={server};DATABASE={database};UID={username};Trusted_Connection=yes'
)

# Carregar o CSV (substituir com suas credenciais) no caso está a usada na minha máquina.
data = pd.read_csv("C:\\Users\\cauar\\input.csv", sep=';')

# Cria um cursor para poder administrar os dados
cursor = connect.cursor()

# Inserir os dados no banco de dados puxando por cada linha retornando um índice (index) e uma série (row)
for index, row in data.iterrows():
    date = datetime.strptime(row['Data'], '%d/%m/%Y').date()
    emolumentostr = row['Emolumentos']
    emolumento = emolumentostr.replace(',', '.')
    cursor.execute('''
        INSERT INTO Ordem (Data_Trade, Ativo, Quantidade, Emolumento)
        VALUES (?, ?, ?, ?)''',
        date, row['Ativo'], row['Quantidade'], emolumento)

# Commit e fechar conexão
connect.commit()
cursor.close()
connect.close()