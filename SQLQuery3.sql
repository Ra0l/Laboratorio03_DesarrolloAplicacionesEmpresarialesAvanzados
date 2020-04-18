use DB_A5A76C_raul966

CREATE PROC USP_ListarPedidosEntreFechas
@FEC1 DATETIME
,@FEC2 DATETIME
AS
BEGIN
SELECT * FROM PEDIDOS
WHERE FechaPedido BETWEEN @FEC1 AND @FEC2
END

EXEC USP_ListarPedidosEntreFechas '1994-08-04','1994-09-16'

CREATE PROC USP_ListarDetalle
@IdPedido INT
AS
BEGIN
SELECT * FROM detallesdepedidos WHERE idpedido=@IdPedido
END



alter procedure usp_pedid 
---aqui se declarana variables
@idpedido int
as
begin
----aqui pon tu consulta

select * from detallesdepedidos where idpedido=@idpedido
end

--ya esta creado
--falta ejecutar
usp_pedid 10248
