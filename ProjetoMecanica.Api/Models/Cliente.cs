using System.Text.Json.Serialization;

namespace ProjetoMecanica.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone {get; set; }
        public string CPF { get; set; }

        [JsonIgnore]
       public ICollection<Veiculo> Veiculos{ get; set; } = new List<Veiculo>();
    }
}
