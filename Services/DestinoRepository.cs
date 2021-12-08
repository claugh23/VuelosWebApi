using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class DestinoRepository
    {
        private string connectionString;

        public DestinoRepository()
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

        public void Add(Destino destino)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Destino (Id_Destino,nAeropuerto,Ciudad,GateAeropuerto) VALUES (@Id_Destino,@nAeropuerto,@Ciudad,@GateAeropuerto)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, destino);
                dbConnection.Close();
            }
        }

        public IEnumerable<Destino> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectDestinos = @"SELECT * FROM Destino";

                dbConnection.Open();
                return dbConnection.Query<Destino>(sqlSelectDestinos);
                dbConnection.Close();
            }

        }
        public Destino Update(Destino usuarioUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateDestino = @"UPDATE Destino SET Nombre=@Nombre,nAeropuerto=@nAeropuerto,Ciudad=@Ciudad,GateAeropuerto=@GateAeropuerto WHERE Id_Destino = @Id_Destino";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateDestino, usuarioUpdate);
                dbConnection.Close();

                return usuarioUpdate;
            }

        }

        public string Delete(int Id_Destino)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteDestino = @"DELETE FROM Destino where Id_Destino=@Id_Destino;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteDestino, new { idUsuario = Id_Destino });
                dbConnection.Close();

                return "Destino: " + Id_Destino + " Eliminado";
            }
        }
    }
}
