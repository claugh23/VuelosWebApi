using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services.Repositories
{
    public class CrearUsuarioRepository
    {
        private readonly Random _random = new Random();
        private string connectionString;

        public CrearUsuarioRepository()
        {
            connectionString = "Data Source=.;Initial Catalog=flights;Integrated Security=True";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public string AuthenticationReponse(CrearUsuario credenciales)
        {
            ArrayList listasUsuarios = new ArrayList();
            using (IDbConnection dbConnection = Connection)
            {
                Errores logAuth = new Errores()
                {
                    id_error = _random.Next(1, 10000000),
                    Fecha = DateTime.Now.ToString("MM/dd/yyyy"),
                    hora = DateTime.Now.ToString("HH:mm:ss"),
                    Mensaje = "AUTENTICACION DE USUARIO"
                };


                string sqlLogsRegister = @"INSERT INTO ERRORES (id_error,Fecha,hora,Mensaje) values(@id_error,@Fecha,@hora,@Mensaje)";
                var LogAuth = dbConnection.Execute(sqlLogsRegister, logAuth);
                //////////////////////////////////////////////////////////////////////////////////////////
                string sqlSelectUser = @"SELECT * FROM CrearUsuario";
                var Usuarios = dbConnection.Query<CrearUsuario>(sqlSelectUser);

              

                foreach (CrearUsuario item in Usuarios)
                {
                    listasUsuarios.Add(item.Email);
                   
                    listasUsuarios.Add(item.Password);
                   
                }
                if (listasUsuarios.Contains(credenciales.Email) && listasUsuarios.Contains(credenciales.Password))
                {
                    return "Autenticado";

                }
                else
                {
                    return "Usuario Incorrecto";
                }
            }
        }

        public void Add(CrearUsuario usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {

                Errores logAuth = new Errores()
                {
                    id_error = _random.Next(1, 10000),
                    Fecha = DateTime.Now.ToString(),
                    hora = DateTime.Today.ToString(),
                    Mensaje = "REGISTRO DE USUARIO"
                };


                string sqlLogsRegister = @"INSERT INTO ERRORES (id_error,Fecha,hora,Mensaje) values(@id_error,@Fecha,@hora,@Mensaje)";
                var LogAuth = dbConnection.Execute(sqlLogsRegister, logAuth);


                string sqlAdd = @"Insert into CrearUsuario (IdUsuario,Nombre,Apellidos,Email,Usuario,Password,ConfPassword,TipoUsuario_IdtiposUsuario) 
                                VALUES (@IdUsuario,@Nombre,@Apellidos,@Email,@Usuario,@Password,@ConfPassword,@TipoUsuario_IdtiposUsuario)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, usuario);
                dbConnection.Close();
            }
        }

        public IEnumerable<CrearUsuario> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectUser = @"SELECT * FROM CrearUsuario";

                dbConnection.Open();
                return dbConnection.Query<CrearUsuario>(sqlSelectUser);
                dbConnection.Close();
            }

        }
        public CrearUsuario Update(CrearUsuario usuarioUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateUser = @"UPDATE CrearUsuario SET Nombre=@Nombre,Apellidos=@Apellidos,Email=@Email,Usuario=@Usuario,Password=@Password,ConfPassword=@ConfPassword,TipoUsuario_IdtiposUsuario=@TipoUsuario_IdtiposUsuario 
                                        WHERE IdUsuario = @IdUsuario";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateUser, usuarioUpdate);
                dbConnection.Close();

                return usuarioUpdate;
            }

        }

        public string Delete(string IdUsuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteUser = @"DELETE FROM CrearUsuario where IdUsuario=@IdUsuario;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteUser, new { idUsuario = IdUsuario });
                dbConnection.Close();

                return "Usuario: " + IdUsuario + " Eliminado";
            }
        }
    }
}
