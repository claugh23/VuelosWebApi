using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class IntinerarioRepository
    {

        private string connectionString;

        public IntinerarioRepository()
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

        public void Add(Intinerario intinerario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Intinerario (Id_Intinerario,Destino_Id_Destino,Origen_Id_Destino,Fecha,Hora) VALUES (@Id_Intinerario,@Destino_Id_Destino,@Origen_Id_Destino,@Fecha,@Hora)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, intinerario);
                dbConnection.Close();
            }
        }

        public IEnumerable<Intinerario> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectIntinerario = @"SELECT * FROM Intinerario";

                dbConnection.Open();
                return dbConnection.Query<Intinerario>(sqlSelectIntinerario);
                dbConnection.Close();
            }

        }
        public Intinerario Update(Intinerario intinerarioUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateDestino = @"UPDATE Intinerario SET Destino_Id_Destino=@Destino_Id_Destino,Origen_Id_Destino=@Origen_Id_Destino,Fecha=@Fecha,@Hora=Hora WHERE Id_Intinerario = @Id_Intinerario";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateDestino, intinerarioUpdate);
                dbConnection.Close();

                return intinerarioUpdate;
            }

        }

        public string Delete(string Id_Intinerario)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteDestino = @"DELETE FROM Intinerario where Id_Intinerario=@Id_Intinerario;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteDestino, new { id_Intinerario = Id_Intinerario });
                dbConnection.Close();

                return "Destino: " + Id_Intinerario + " Eliminado";
            }
        }
    }
}
