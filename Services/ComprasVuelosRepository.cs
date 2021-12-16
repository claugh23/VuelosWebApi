using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using VuelosWebApi.Models;

namespace VuelosWebApi.Services
{
    public class ComprasVuelosRepository
    {
        private readonly Random _random = new Random();
        private string connectionString;

        public ComprasVuelosRepository()
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

        public IEnumerable<ComprasVuelos> GetAllComprasVuelos()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sqlSelectComprasVuelos = @"SELECT * FROM ComprasVuelos";

                dbConnection.Open();
                return dbConnection.Query<ComprasVuelos>(sqlSelectComprasVuelos);
                dbConnection.Close();
            }

        }

        public void PostVueloCompra(ComprasVuelos vueloCompra)
        {
            using (IDbConnection dbConnection = Connection)
            {

                Errores logAuth = new Errores()
                {
                    id_error = _random.Next(1, 10000),
                    Fecha = DateTime.Now.ToString(),
                    hora = DateTime.Today.ToString(),
                    Mensaje = "COMPRA DE VUELO GENERADA"
                };

                string sqlLogsRegister = @"INSERT INTO ERRORES (id_error,Fecha,hora,Mensaje) values(@id_error,@Fecha,@hora,@Mensaje)";
                var LogAuth = dbConnection.Execute(sqlLogsRegister, logAuth);


                string sqlAdd = @"Insert into ComprasVuelos (Id_CompraVuelo,Precio,AeroLinea,HoraSalida,HoraLlegada,EstadoVuelo,PuertaAbordaje) 
                                VALUES (@Id_CompraVuelo,@Precio,@AeroLinea,@HoraSalida,@HoraLlegada,@EstadoVuelo,@PuertaAbordaje)";
                dbConnection.Open();
                dbConnection.Execute(sqlAdd, vueloCompra);
                dbConnection.Close();
            }

        }

    }
}
