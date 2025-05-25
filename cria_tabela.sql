CREATE TABLE
	Ativo
(
	ID				INT	IDENTITY(1,1)		PRIMARY KEY,
	Descricao		VARCHAR(50)				NOT NULL
)

CREATE TABLE
	Ordem
(
	ID				INT IDENTITY(1,1)		PRIMARY KEY,
	ID_Ativo		INT						NOT NULL,
	Data_Trade		DATE					NOT NULL,
	Quantidade		INT						NOT NULL,
	Emolumento		FLOAT					NOT NULL
)

CREATE TABLE
	Posicao
(
	ID				INT IDENTITY(1,1)		PRIMARY KEY,
	ID_Ativo		INT						NOT NULL,
	Data_Posicao	DATE					NOT NULL,
	Quantidade		INT						NOT NULL
)