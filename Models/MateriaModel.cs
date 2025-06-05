using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.Identity.Client;

namespace SaberKids.Models
{
    public class MateriaModel
    {
        public int Id { get; set; }
        public string Nome {  get; set; }
        public string Descricao { get; set; }
    }
}
