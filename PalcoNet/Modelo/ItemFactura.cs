namespace PalcoNet.Modelo
{
    public class ItemFactura
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int Cantidad { get; set; }
        public double Monto { get; set; }
    }
}