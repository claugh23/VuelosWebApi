using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class TarjetaRepository
    {
        private string connectionString;

        public TarjetaRepository()
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

        public void Add(Tarjeta origenNuevo)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into Tarjeta (Id_Pago,nTarjeta,NombreTarjeta,fechaExpiracion) VALUES (@Id_Pago,@nTarjeta,@NombreTarjeta,@fechaExpiracion)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, origenNuevo);
                dbConnection.Close();
            }
        }

        public IEnumerable<Tarjeta> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectedTarjeta = @"SELECT * FROM Tarjeta";

                dbConnection.Open();
                return dbConnection.Query<Tarjeta>(sqlSelectedTarjeta);
                dbConnection.Close();
            }

        }
        public Tarjeta Update(Tarjeta tarjetUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateTarjeta = @"UPDATE Tarjeta SET nTarjeta=@nTarjeta,NombreTarjeta=@NombreTarjeta,@fechaExpiracion=fechaExpiracion WHERE Id_Pago = @Id_Pago";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateTarjeta, tarjetUpdate);
                dbConnection.Close();

                return tarjetUpdate;
            }

        }

        public string Delete(string Id_Tarjeta)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteOrigen = @"DELETE FROM Origen where Id_Origen=@Id_Origen;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteOrigen, new { id_Origen = Id_Tarjeta });
                dbConnection.Close();

                return "Destino: " + Id_Tarjeta + " Eliminado";
            }
        }
    }
}
