using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoMecanica.Api.Models
{
    public class Agendamentos
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string servico { get; set; }
        public int VeiculoId { get; set; }
    }
}
