using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using Microsoft.Identity.Client;

namespace SaberKids.Models
{
    public class TurmaMateriaModel
    {
        public int Id { get; set; }
        public int? TurmaId { get; set; }
        public int? MateriaId { get; set; }
        [JsonIgnore]
        public virtual TurmaModel? Turma { get; set; }
        [JsonIgnore]
        public virtual MateriaModel? Materia { get; set; }
    }
}
