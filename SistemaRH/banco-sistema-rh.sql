CREATE DATABASE sistema_rh_db

USE sistema_rh_db

CREATE TABLE tbAliquotas(
	id int IDENTITY PRIMARY KEY NOT NULL,
	anoVigencia int NOT NULL,
	descricao varchar(50) NOT NULL,
	desconta bit NOT NULL,
)

CREATE TABLE tbAliquotaDetalhes (
	id int IDENTITY PRIMARY KEY NOT NULL,
	idAliquota int NOT NULL FOREIGN KEY (idAliquota) REFERENCES tbAliquotas(id),
	baseCalculo decimal(9, 2) NOT NULL,
	porcentagem decimal(5, 2) NOT NULL,
)

CREATE TABLE tbFuncionarios(
	id int IDENTITY PRIMARY KEY NOT NULL,
	dataAdmissao date not null,
	nome varchar(50) NOT NULL,
)

CREATE TABLE tbFuncionarioSalario(
	id int identity primary key not null,
	idFuncionario int FOREIGN KEY (idFuncionario) REFERENCES tbFuncionarios(id),
	salario decimal(9,2) not null,
	vigenteEm date not null
)

CREATE TABLE tbPagamentos(
	id int IDENTITY PRIMARY KEY NOT NULL,
	dataPagamento date NOT NULL,
	dataReferencia date not null,
	idFuncionarioSalario int foreign key (idFuncionarioSalario) references tbFuncionarioSalario (id) NOT NULL,
	salarioLiquido decimal(9, 2) NULL,
)