using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services.Repositories
{
    public class CrearUsuarioRepository
    {
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

        public void Add(CrearUsuario usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
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
