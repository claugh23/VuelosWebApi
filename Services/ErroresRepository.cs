using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class ErroresRepository
    {
        private string connectionString;

        public ErroresRepository()
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

        public void Add(Errores errores)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Errores (id_error,Fecha,Hora,Mensaje) VALUES (@id_error,@Fecha,@Hora,@Mensaje)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, errores);
                dbConnection.Close();
            }
        }

        public IEnumerable<Errores> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectDestinos = @"SELECT * FROM Errores";

                dbConnection.Open();
                return dbConnection.Query<Errores>(sqlSelectDestinos);
                dbConnection.Close();
            }

        }
     
    }
}
