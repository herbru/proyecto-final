CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertarUsuario`(
in PNombre       varchar(45), 
in PApellido varchar(45),
in PEmail   varchar(45),
in PContrasena   varchar(45),
in PImagen      varchar(45)
)
begin
insert into Usuarios (Nombre,Apellido,Email,Contrasena,Imagen)values (PNombre , PApellido,PEmail ,PContrasena,PImagen );
end