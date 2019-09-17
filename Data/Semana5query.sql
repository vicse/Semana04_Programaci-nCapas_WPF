use neptuno;

-- INSERTAR CATEGORIA
alter PROC USP_InsCategoria
@idcategoria INT,
@nombrecategoria varchar(100),
@descripcion text
AS
BEGIN 
--DECLARE @idcategoria INT
--SET @idcategoria= (SELECT MAX(Idcategoria)+1 from categorias)
INSERT INTO categorias(idcategoria, nombrecategoria, descripcion, estado)
VALUES (@idcategoria, @nombrecategoria, @descripcion, 1)
END

-- ACTUALIZAR CATEGORIA
CREATE PROC USP_UpdCategoria
@idcategoria INT,
@nombrecategoria varchar(100),
@descripcion text
AS
BEGIN
UPDATE categorias SET nombrecategoria=@nombrecategoria, descripcion=@descripcion
WHERE idcategoria=@idcategoria
END

-- ELIMINAR CATEGORIA
create proc USP_DeleteCategoria
@idcategoria int
as
begin
update categorias set estado = 0
where idcategoria =@idcategoria 
end

--CREATE PROC USP

-- MOSTRAR CATEGORIAS
alter PROC USP_GetCategoria
@idcategoria INT=0
AS
BEGIN
SELECT Idcategoria, nombrecategoria, descripcion,estado
FROM categorias
WHERE idcategoria=@idcategoria or @idcategoria=0 and estado != 0
END

update categorias set estado = 1

alter table categorias
add estado bit 

delete from categorias 