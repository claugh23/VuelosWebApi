using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class UsuarioRepository
    {
        private string connectionString;

        public UsuarioRepository()
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

        public void Add(Usuarios usuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Usuarios (Id_Cliente,Nombre,Apellidos,Email,Tarjeta_Id_Pago) VALUES (@Id_Cliente,@Nombre,@Apellidos,@Email,@Tarjeta_Id_Pago)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, usuario);
                dbConnection.Close();
            }
        }

        public IEnumerable<Usuarios> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectUsuario = @"SELECT * FROM Usuarios";

                dbConnection.Open();
                return dbConnection.Query<Usuarios>(sqlSelectUsuario);
                dbConnection.Close();
            }

        }
        public Usuarios Update(Usuarios usuarioUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateDestino = @"UPDATE Usuarios SET Nombre=@Nombre,Apellidos=@Apellidos,Email=@Email,Tarjeta_Id_Pago=@Tarjeta_Id_Pago WHERE Id_Cliente = @Id_Cliente";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateDestino, usuarioUpdate);
                dbConnection.Close();

                return usuarioUpdate;
            }

        }

        public string Delete(int IdUsuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteDestino = @"DELETE FROM Usuarios where Id_Cliente=@Id_Cliente;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteDestino, new { idUsuario = IdUsuario });
                dbConnection.Close();

                return "Usuario: " + IdUsuario + " Eliminado";
            }
        }
    }
}
