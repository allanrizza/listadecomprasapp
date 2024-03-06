using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaDeComprasApp
{
    public class Item
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
        [Required]
        public bool Comprado { get; set; }

        public Item(string nome, int quantidade)
        {
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.Comprado = false;
        }
    }
}
