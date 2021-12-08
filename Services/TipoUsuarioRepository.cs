using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class TipoUsuarioRepository
    {
        private string connectionString;

        public TipoUsuarioRepository()
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

        public void Add(TipoUsuario origenNuevo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into TipoUsuario (IdTiposUsuarios,Nombre_tipos_Usuarios,Tipo) VALUES (@IdTiposUsuarios,Nombre_tipos_Usuarios,Tipo)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, origenNuevo);
                dbConnection.Close();
            }
        }

        public IEnumerable<TipoUsuario> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectedOrigen = @"SELECT * FROM TipoUsuario";

                dbConnection.Open();
                return dbConnection.Query<TipoUsuario>(sqlSelectedOrigen);
                dbConnection.Close();
            }

        }
        public TipoUsuario Update(TipoUsuario origenUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateOrigen = @"UPDATE TipoUsuario SET Nombre_tipos_Usuarios=@Nombre_tipos_Usuarios,Tipo=@Tipo WHERE IdTiposUsuarios = @IdTiposUsuarios";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateOrigen, origenUpdate);
                dbConnection.Close();

                return origenUpdate;
            }

        }

        public string Delete(int Id_TipoUsuario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteOrigen = @"DELETE FROM TipoUsuario where IdTiposUsuarios=@IdTiposUsuarios;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteOrigen, new { id_Origen = Id_TipoUsuario });
                dbConnection.Close();

                return "TipoUsuario: " + Id_TipoUsuario + " Eliminado";
            }
        }
    }
}
