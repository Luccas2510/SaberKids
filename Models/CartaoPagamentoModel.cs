using System.Text.Json.Serialization;

namespace SaberKids.Models
{
    public class CartaoPagamentoModel
    {
        public int Id { get; set; }
        public int? CartaoId { get; set; }
        public int? PagamentoId { get; set; }
        [JsonIgnore]
        public virtual CartaoModel? Cartao { get; set; }
        [JsonIgnore]
        public virtual PagamentoModel? Pagamento { get; set; }
    }
}
