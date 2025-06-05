using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace SaberKids.Models
{
    public class CursoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public int? UsuarioId { get; set; }
        public int? TurmaId { get; set; }
        [JsonIgnore]
        public virtual UsuarioModel? Usuario { get; set; }
        [JsonIgnore]
        public virtual TurmaModel? Turma { get; set; }
    }
}
