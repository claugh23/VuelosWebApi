using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class OrigenRepository
    {
        private string connectionString;

        public OrigenRepository()
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

        public void Add(Origen origenNuevo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Origen (Id_Origen,nAeropuerto,Ciudad,GateAeropuerto) VALUES (@Id_Origen,@nAeropuerto,@Origen_Id_Destino,@Ciudad,@GateAeropuerto)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, origenNuevo);
                dbConnection.Close();
            }
        }

        public IEnumerable<Origen> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectedOrigen = @"SELECT * FROM Origen";

                dbConnection.Open();
                return dbConnection.Query<Origen>(sqlSelectedOrigen);
                dbConnection.Close();
            }

        }
        public Origen Update(Origen origenUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateOrigen = @"UPDATE Origen SET nAeropuerto=@nAeropuerto,Ciudad=@Ciudad,@GateAeropuerto=GateAeropuerto WHERE Id_Origen = @Id_Origen";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateOrigen, origenUpdate);
                dbConnection.Close();

                return origenUpdate;
            }

        }

        public string Delete(string Id_Origen)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteOrigen = @"DELETE FROM Origen where Id_Origen=@Id_Origen;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteOrigen, new { id_Origen = Id_Origen });
                dbConnection.Close();

                return "Destino: " + Id_Origen + " Eliminado";
            }
        }
    }
}
