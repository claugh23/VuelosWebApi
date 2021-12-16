namespace VuelosWebApi.Models
{
    public class ComprasVuelos
    {
        public int Id_CompraVuelo { get; set; }
        public int Precio { get; set; }
        public string AeroLinea { get; set; }
        public string HoraSalida { get; set; }
        public string HoraLlegada { get; set; }
        public string EstadoVuelo { get; set; }
        public string PuertaAbordaje { get; set; }
    }
}
