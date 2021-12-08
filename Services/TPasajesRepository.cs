using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    //PENDIENTE DE TERMINAR PARA PASAR A TABLA USUARIOS
    public class TPasajesRepository
    {
        private string connectionString;

        public TPasajesRepository()
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

        public void Add(TPasaje destino)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlAdd = @"Insert into TPasaje (Id_pasaje,Usuarios_Id_Cliente,Vuelos_Id_Pago) VALUES (@Id_pasaje,@Usuarios_Id_Cliente,@Vuelos_Id_Pago)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, destino);
                dbConnection.Close();
            }
        }

        public IEnumerable<TPasaje> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectPasajes = @"SELECT * FROM TPasaje";

                dbConnection.Open();
                return dbConnection.Query<TPasaje>(sqlSelectPasajes);
                dbConnection.Close();
            }

        }
        public TPasaje Update(TPasaje pasajeUpdate)
        {

            using (IDbConnection dbConnection = Connection)
            {
                string sqlUpdateDestino = @"UPDATE TPasaje SET Usuarios_Id_Clientes=@Usuarios_Id_Clientes,Vuelos_Id_Vuelo=@Vuelos_Id_Vuelo WHERE Id_pasaje = @Id_pasaje";

                dbConnection.Open();
                dbConnection.Execute(sqlUpdateDestino, pasajeUpdate);
                dbConnection.Close();

                return pasajeUpdate;
            }

        }

        public string Delete(int IdPasaje)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlDeleteDestino = @"DELETE FROM TPasaje where Id_pasaje=@Id_pasaje;";

                dbConnection.Open();
                dbConnection.Query(sqlDeleteDestino, new { idUsuario = IdPasaje });
                dbConnection.Close();

                return "Pasaje: " + IdPasaje + " Eliminado";
            }
        }
    }
}
