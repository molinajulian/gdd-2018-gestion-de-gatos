use GD2C2018
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[obtenerLetra]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].[obtenerLetra];
go
create function obtenerLetra(@posicion numeric(11))
returns char(1) 

begin 
if(@posicion=0)
return'a' 
if(@posicion=1)
return'b' 
if(@posicion=2)
return'c' 
if(@posicion=3)
return 'd'
if(@posicion=4)
return'e' 
if(@posicion=5)
return'f'
if(@posicion=6)
return'g' 
if(@posicion=7)
return'h' 
if(@posicion=8)
return'i' 
if(@posicion=9)
return'j' 
if(@posicion=10)
return'k' 
if(@posicion=11)
return'l' 
if(@posicion=12)
return'm' 
if(@posicion=13)
return'n' 
if(@posicion=14)
return'o' 
if(@posicion=15)
return'p' 
if(@posicion=16)
return'q' 
if(@posicion=17)
return'r' 
if(@posicion=18)
return's' 
if(@posicion=19)
return't' 
if(@posicion=20)
return 'u'
if(@posicion=21)
return'v' 
if(@posicion=22)
return'w' 
if(@posicion=23)
return'x' 
if(@posicion=24)
return'y' 
if(@posicion=25)
return'z' 
return '!'
end;




go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'obtenerTrimestre')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function obtenerTrimestre;
go
create function obtenerTrimestre(@fecha Date)
returns int
as
begin
declare @numeroTrimestre int
set @numeroTrimestre= case	when Month(@fecha)/3 between 0 and 1 then 1
							when Month(@fecha)/3 between 1 and 2 then 2
							when Month(@fecha)/3 between 2 and 3 then 3
							when Month(@fecha)/3 between 3 and 4 then 4
					  end
return @numeroTrimestre
end;
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'empresasConLocalidadesSinVender')
           AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function empresasConLocalidadesSinVender;

go

use GD2C2018
go
create function empresasConLocalidadesSinVender (@gradoVisibilidad numeric(11), @mes int,@año int, @trimestre int)
returns table
as
return(
	select top 5  * from(select top 5  emp.Emp_Razon_Social,esp.Espec_Fecha, grad.Grado_Descr
	 from GESTION_DE_GATOS.Empresas emp
	join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Emp_Cuit=emp.Emp_Cuit
	join GESTION_DE_GATOS.Ubicaciones ubi on  ubi.Ubic_Espec_Cod = esp.Espec_Cod
	join GESTION_DE_GATOS.Publicaciones pub on pub.Public_Espec_Cod= esp.Espec_Cod
	join GESTION_DE_GATOS.Grados grad on Public_Grado_Cod=grad.Grado_Cod
	where (@gradoVisibilidad is null Or Public_Estado_Id = @gradoVisibilidad) and ((@mes is null) OR Month(Espec_Fecha)=@mes) and (Year(Espec_Fecha)=@año or @año is null)
	and ubi.Ubic_Compra_Id is null and @trimestre= [dbo].[obtenerTrimestre](esp.Espec_Fecha)
	group by emp.Emp_Razon_Social, esp.Espec_Fecha,grad.Grado_Descr
	order by Count(Ubic_Id) DESC) empre
	order by empre.Espec_Fecha DESC, empre.Grado_Descr
)
GO
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'clientesConMayoresPuntosVencidos')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function clientesConMayoresPuntosVencidos
;
go
create function clientesConMayoresPuntosVencidos (@año int, @trimestre int )
returns table
as

return(
select top 5 concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc)) as Cliente,SUM(pun.Puntos_Cantidad) as Cantidad
from GESTION_DE_GATOS.Clientes cli
join GESTION_DE_GATOS.Puntos pun on cli.Cli_Tipo_Doc_Id= pun.Cli_Tipo_Doc and cli.Cli_Doc=pun.Cli_Doc
where  @trimestre> [dbo].[obtenerTrimestre](pun.Puntos_FechaVencimiento) and @año>=year(pun.Puntos_FechaVencimiento)
group by  concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc))
order by sum(pun.Puntos_Cantidad) DESC
)
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'clientesConMayorCantidadDeComprasPorEmpresa')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function clientesConMayorCantidadDeComprasPorEmpresa
go
create  function clientesConMayorCantidadDeComprasPorEmpresa (@año int,@trimestre int)
returns table

as 

return(
select top 5 concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc)) as Cliente,COUNT(comp.Compra_Id)as Cantidad,Emp_Cuit as Empresa
 from GESTION_DE_GATOS.Clientes cli
join GESTION_DE_GATOS.Compras comp on comp.Compra_Cli_Tipo_Doc=cli.Cli_Tipo_Doc_Id and comp.Compra_Cli_Doc=cli.Cli_Doc
join GESTION_DE_GATOS.Publicaciones publ on publ.Public_Cod=comp.Compra_Publicacion
join GESTION_DE_GATOS.Espectaculos esp on publ.Public_Espec_Cod= esp.Espec_Cod
join GESTION_DE_GATOS.Empresas emp on Espec_Emp_Cuit= emp.Emp_Cuit
where @trimestre= [dbo].[obtenerTrimestre](comp.Compra_Fecha) and year(comp.Compra_Fecha)=@año
group by concat(convert(nvarchar(16),cli.Cli_Tipo_Doc_Id),convert(nvarchar(11),cli.Cli_Doc)), Emp_Cuit
order by Count(comp.Compra_Id) DESC
);
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'consultarPuntos')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function consultarPuntos;
go
create function consultarPuntos(@idCliente nvarchar (16), @fechaHoy datetime)
returns int 
as
begin
declare @puntos int
set @puntos= (select Sum(pun.Puntos_Cantidad) from GESTION_DE_GATOS.Clientes cli
			  join GESTION_DE_GATOS.Puntos pun on concat(convert(nvarchar(16),pun.Cli_Tipo_Doc),convert(nvarchar(11),pun.Cli_Doc))=@idCliente
			  
			  where pun.Puntos_FechaVencimiento>@fechaHoy
			  group by concat(convert(nvarchar(16),pun.Cli_Tipo_Doc),convert(nvarchar(11),pun.Cli_Tipo_Doc)))
return @puntos
end
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'comprasMasAntiguas')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function comprasMasAntiguas;

go
create function comprasMasAntiguas(@cantidad int, @empresaCuit nvarchar(255))
returns table
as
return(
select top (@cantidad) comp.Compra_Id from GESTION_DE_GATOS.Compras comp
join  GESTION_DE_GATOS.Publicaciones publ on publ.Public_Cod=comp.Compra_Publicacion
join GESTION_DE_GATOS.Espectaculos esp on publ.Public_Espec_Cod= esp.Espec_Cod
where Espec_Emp_Cuit=@empresaCuit and comp.Compra_Fue_Facturada =0
order by comp.Compra_Fecha ASC);
go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'rendirItemsFactura')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' )  )
drop function rendirItemsFactura;
go

create function rendirItemsFactura(@cantidad int, @empresaCuit nvarchar(255))
Returns TABLE
as
return(
select 
sum(ubi.Ubic_Precio*Grado_Comision) as monto, Count(ubi.Ubic_Id) as cantidad  
from GESTION_DE_GATOS.Publicaciones publ
join GESTION_DE_GATOS.Grados gra on publ.Public_Grado_Cod=gra.Grado_Cod
join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Cod= publ.Public_Espec_Cod
join GESTION_DE_GATOS.Ubicaciones ubi on ubi.Ubic_Espec_Cod=esp.Espec_Cod
join GESTION_DE_GATOS.Compras comp on comp.Compra_Publicacion=Public_Cod
where comp.Compra_Id in( select * from comprasMasAntiguas(@cantidad,@empresaCuit)) 
group by  comp.Compra_Id
)
 go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'GenerarRendicionComisiones')
            AND type IN ( N'P', N'PC' ) )
drop procedure GenerarRendicionComisiones;

go
create procedure GenerarRendicionComisiones (@cantidad int,@empresaCuit nvarchar(255), @username varchar(255),@fechaHoy datetime)
 as
 begin 
  declare @tienePermisos char(3),@ultimaFactura numeric(18)
		begin transaction
		begin try
			INSERT into  GESTION_DE_GATOS.Facturas (Fact_Emp_Cuit, Fact_Fecha)
			values(@empresaCuit,@fechaHoy)
			set @ultimaFactura= (select top 1 f.Fact_Num from GESTION_DE_GATOS.Facturas f order by f.Fact_Num desc)
			insert into GESTION_DE_GATOS.Item_Facturas (Item_Fact_Num,Item_Fact_Monto,Item_Fact_Cant)
			select @ultimaFactura,* from rendirItemsFactura(@cantidad,@empresaCuit)
			update GESTION_DE_GATOS.Facturas 
			set Fact_Total= (select sum(ifact.Item_Fact_Cant*ifact.Item_Fact_Monto) from GESTION_DE_GATOS.Item_Facturas ifact where ifact.Item_Fact_Num =@ultimaFactura group by ifact.Item_Fact_Id  )
			where Fact_Num= @ultimaFactura
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al hacer la  rendicion de comisiones, motivo: %s',16,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
		end
 go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[calcularPuntos]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].calcularPuntos;
go
create function calcularPuntos (@cantidadUbicaciones int , @fecha smalldatetime)
returns int
as
begin
declare @salida int  
set @salida=@cantidadUbicaciones * 100
return @salida
end
go

IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[localidadesDisponibles]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].localidadesDisponibles;
go 

create function localidadesDisponibles (@unaPublicacion int)
returns table
as 


return(select ubi.Ubic_Id from GESTION_DE_GATOS.Publicaciones publ 
		join GESTION_DE_GATOS.Espectaculos esp on publ.Public_Espec_Cod=esp.Espec_Cod
		join GESTION_DE_GATOS.Ubicaciones ubi on ubi.Ubic_Espec_Cod=esp.Espec_Cod
		where ubi.Ubic_Compra_Id is null)

go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[existeEspectaculoMismaHoraMismoLugar]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].existeEspectaculoMismaHoraMismoLugar
go 
create function existeEspectaculoMismaHoraMismoLugar(@fecha datetime, @domicilioId int)
returns int
as
begin
declare @salida int
set @salida= (select Count(*) from GESTION_DE_GATOS.Espectaculos esp where esp.Espec_Fecha= @fecha and esp.Espec_Dom_Id=@domicilioId )
return @salida
end			
go
use GD2C2018
go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'[dbo].[obtenerItemsDeCompras]')
            AND type IN ( N'FN', N'IF', N'TF', N'FS', N'FT' ) )
drop function [dbo].obtenerItemsDeCompras
go
create function obtenerItemsDeCompras(@PublicacionCod int )
returns table

as

return(select sum(ubi.Ubic_Precio*Grado_Comision) as monto, Count(ubi.Ubic_Id) as cantidad  
						from GESTION_DE_GATOS.Publicaciones publ
						join GESTION_DE_GATOS.Grados gra on publ.Public_Grado_Cod=gra.Grado_Cod
						join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Cod= publ.Public_Espec_Cod
						join GESTION_DE_GATOS.Ubicaciones ubi on ubi.Ubic_Espec_Cod=esp.Espec_Cod
						join GESTION_DE_GATOS.Compras comp on comp.Compra_Publicacion=Public_Cod
						where comp.Compra_Publicacion=@PublicacionCod  and comp.Compra_Fue_Facturada=0
						group by  comp.Compra_Id)


 go
IF EXISTS ( SELECT  *
            FROM    sys.objects
            WHERE   object_id = OBJECT_ID(N'FacturarPublicacion')
            AND type IN ( N'P', N'PC' ) )
drop procedure FacturarPublicacion;

go
create procedure FacturarPublicacion(@PublicacionCod int,@fechaHoy datetime)
as
	declare @ultimaFactura numeric(18)
	declare @empresaCuit nvarchar(255)
	declare @esFinalizada int
		set @empresaCuit= (select top 1 esp.Espec_Emp_Cuit
							from GESTION_DE_GATOS.Publicaciones publ join GESTION_DE_GATOS.Espectaculos esp on esp.Espec_Cod=publ.Public_Espec_Cod
							where publ.Public_Cod=@PublicacionCod)	
		set @esFinalizada= (select top 1 publ.Public_Estado_Id from GESTION_DE_GATOS.Publicaciones publ where publ.Public_Cod=@PublicacionCod)
		begin transaction
		begin try
		if(@esFinalizada=3)
		begin 
			INSERT into  GESTION_DE_GATOS.Facturas (Fact_Emp_Cuit, Fact_Fecha)
			values(@empresaCuit,@fechaHoy)
			set @ultimaFactura= (select top 1 f.Fact_Num from GESTION_DE_GATOS.Facturas f order by f.Fact_Num desc)
			insert into GESTION_DE_GATOS.Item_Facturas (Item_Fact_Num,Item_Fact_Monto,Item_Fact_Cant) 
                SELECT @ultimaFactura, * FROM obtenerItemsDeCompras(@PublicacionCod)
			update GESTION_DE_GATOS.Facturas
			set Fact_Total = (select sum(ifact.Item_Fact_Cant*ifact.Item_Fact_Monto) 
                                from GESTION_DE_GATOS.Item_Facturas ifact 
                                where ifact.Item_Fact_Num =@ultimaFactura)
			where Fact_Num = @ultimaFactura
		end
		else throw 11,'La publicacion no esta finalizada',1	 
		end try
		begin catch
		IF @@TRANCOUNT > 0  
			rollback transaction;
		declare @mensajeError nvarchar(4000)
		SELECT @mensajeError = ERROR_MESSAGE() 
		RAISERROR('Hubo un error al realizar la factura, motivo: %s',16,1,@mensajeError)
		end catch
		IF @@TRANCOUNT > 0  
        commit transaction;
		
go
