using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class VueloRepository
    {
        private string connectionString;

        public VueloRepository()
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

        public void Add(Vuelo vuelo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Vuelo (Id_Vuelo,Compani_Id_Compani,Intinerario_Id_Intinerario,Capacidad,NumeroVuelo) VALUES (@Id_Vuelo,@Compani_Id_Compani,@Intinerario_Id_Intinerario,@Capacidad,@NumeroVuelo)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, vuelo);
                dbConnection.Close();
            }
        }

        public IEnumerable<Vuelo> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectVuelo = @"SELECT * FROM Vuelo";

                dbConnection.Open();
                return dbConnection.Query<Vuelo>(sqlSelectVuelo);
                dbConnection.Close();
            }

        }
        public Vuelo Update(Vuelo vueloUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateVuelo = @"UPDATE Vuelo SET Capacidad=@Capacidad,NumeroVuelo=@NumeroVueloo WHERE Id_Vuelo = @Id_Vuelo";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateVuelo, vueloUpdate);
                dbConnection.Close();

                return vueloUpdate;
            }

        }

        public string Delete(int Id_Vuelo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteVuelo = @"DELETE FROM Vuelo where Id_Vuelo=@Id_Vuelo;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteVuelo, new { idUsuario = Id_Vuelo });
                dbConnection.Close();

                return "Vuelo: " + Id_Vuelo + " Eliminado";
            }
        }
    }
}
