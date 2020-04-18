use DB_A5A76C_raul966

EXEC USP_ListarPedidosEntreFechas '1994-08-04','1994-08-16';

EXEC USP_ListarDetalle 10252;

ALTER PROCEDURE USP_Total
@IdPedido INT,
@Total MONEY OUTPUT
AS
BEGIN
SET @Total = (select sum (preciounidad*cantidad)
from detallesdepedidos
where idpedido = @IdPedido)
END;

EXEC USP_Total 10248;

-----------
-- Actividad Caso 1
-- SP #1

select * from dbo.Empleados;
select * from dbo.Pedidos;
select * from Empleados;
select * from dbo.detallesdepedidos;

CREATE PROCEDURE USP_ListarPedidosAnio
AS
BEGIN
	SELECT CAST(YEAR(FechaPedido) AS VARCHAR(4)) anio
	from Pedidos
	GROUP BY YEAR(FechaPedido)
END;

EXECUTE USP_ListarPedidosAnio

--------Procemiento almacenado P2

create procedure USP_ListarPedidosMes
@Anio VARCHAR(4)
as
begin
	SELECT CAST(MONTH(FechaPedido) AS VARCHAR(2)) mes
	from Pedidos
	where CAST(YEAR(FechaPedido) AS VARCHAR(4)) = @Anio
	GROUP BY MONTH(FechaPedido)
	order by MONTH(FechaPedido)
end;

exec USP_ListarPedidosMes '1995';

---------Procemiendto almacenado 3

-- SP #3

create procedure USP_ListarEmpleados
@Mes varchar(2),
@Anio varchar(4)
as
begin
	select e.IdEmpleado, e.Apellidos, e.Nombre, e.cargo
	from Pedidos p join Empleados e
	on (p.IdEmpleado = e.IdEmpleado)
	where CAST(MONTH(p.FechaPedido) AS VARCHAR(2)) = @Mes and CAST(YEAR(p.FechaPedido) AS VARCHAR(4)) = @Anio;
end;

USP_ListarEmpleados '8', '1994';