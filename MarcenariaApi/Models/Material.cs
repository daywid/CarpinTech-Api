using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaApi.Models
{
    public class Material
    {
        [Key]
        public int id { get; set; }
        public string? nome { get; set; }
        public Double custo { get; set; }
        public int estoqueId { get; set; }

        [JsonIgnore]
        public Estoque? estoque;

        public int tarefaId { get; set; }

        [JsonIgnore]
        public Tarefa? Tarefa;
    }
}
