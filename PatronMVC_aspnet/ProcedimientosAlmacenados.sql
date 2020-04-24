--Busqueda de datos exactos
SELECT * FROM Clientes WHERE Nombre='fernando'
--Busqueda de datos por Aproximacion 
SELECT * FROM Clientes WHERE Nombre LIKE 'Fe%'
--PROCEDIMIENTO
CREATE PROC VerRegistros
@Condicion nvarchar(30)
as
select *from Clientes where ID like @Condicion+'%' or Nombre like @Condicion+'%' 
go
exec VerRegistros 'Fer'