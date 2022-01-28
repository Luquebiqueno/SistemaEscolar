Use SistemaEscolar
Go

If Object_Id('Usuario') Is Null 
Begin
	Create Table Usuario 
	(
		 UsuarioId				Int Identity(1,1) Primary Key
		,Nome					Varchar(128)	Not Null
		,Login					Varchar(128)	Not Null Unique
		,Senha					Varchar(128)	Not Null
		,RefreshToken			Varchar(500)		Null
		,RefreshTokenExpiryTime	DateTime			Null
		,Ativo					Bit				Not Null
	)
End
Go

If Object_Id('Aluno') Is Null 
Begin
	Create Table Aluno 
	(
		 AlunoId			Int Identity(1,1) Primary Key
		,Nome				Varchar(128)	Not Null
		,Telefone			BigInt				Null
		,Media				Decimal(4,2)	Not	Null Default(0)
		,DataCadastro		DateTime		Not Null Default(GetDate())
		,UsuarioCadastro	Int				Not Null
		,DataAlteracao		DateTime			Null
		,UsuarioAlteracao	Int					Null
		,Ativo				Bit				Not Null
	)
End
Go
