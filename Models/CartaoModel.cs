namespace SaberKids.Models
{
    public class CartaoModel
    {
        public int Id { get; set; }
        public string NomeCartao { get; set; }
        public long NumeroCartao { get; set; }
        public string TipoCartao {  get; set; }
        public string Descricao { get; set; }
        public string BandeiraCartao { get; set; }
        public DateOnly DataVenci { get; set; }
        public int CodeCartao { get; set; }
    }
}
