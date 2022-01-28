Use SistemaEscolar
Go

If Not Exists (Select Top 1 1 From Usuario (Nolock)) 
Begin
	Insert Into Usuario
	(
		 Nome	
		,Login	
		,Senha	
		,Ativo	
	)
	Values
	 ('Usuario1', 'usuario1', '12345', 1)
	,('Usuario2', 'usuario2', '12345', 1)
End
Go
