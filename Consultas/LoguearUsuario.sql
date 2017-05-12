CREATE DEFINER=`root`@`localhost` PROCEDURE `LoguearUsuario`(
in PEmail       varchar(45), 
in PContrasena varchar(45)
)
begin
select Nombre,Apellido,Email,Contrasena from Usuarios where Email=PEmail and Contrasena=PContrasena;

end