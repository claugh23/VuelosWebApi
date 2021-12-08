using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services.Repositories
{
    public class CompaniRepository
    {
        private string connectionString;

        public CompaniRepository()
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

        public void Add(Compani compani)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Compani (Id_Compani,Nombre,) VALUES (@Id_Compani,@Nombre)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, compani);
                dbConnection.Close();
            }
        }

        public IEnumerable<Compani> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectCompani = @"SELECT * FROM Compani";

                dbConnection.Open();
                return dbConnection.Query<Compani>(sqlSelectCompani);
                dbConnection.Close();
            }

        }
        public Compani Update(Compani companiUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateUser = @"UPDATE Compani SET Nombre=@Nombre WHERE Id_Compani = @Id_Compani";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateUser, companiUpdate);
                dbConnection.Close();

                return companiUpdate;
            }

        }

        public string Delete(int IdCompani)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteUser = @"DELETE FROM Compani where Id_Compani=@Id_Compani;";
                 
                dbConnection.Open();
                dbConnection.Query(sqlDeleteUser, new { idUsuario = IdCompani });
                dbConnection.Close();

                return "Compani: " + IdCompani + " Eliminado";
            }
        }
    }
}
