using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SaberKids.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string NomeResp { get; set; }
        public string NomeAluno { get; set; }
        public DateOnly DataNasci { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [JsonIgnore]
        public virtual CartaoModel? Cartao { get; set; }
    }
}
