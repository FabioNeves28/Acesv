using Acesvv.Areas.Identity.Data;
using Acesvv.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acesv.Models

{
    public enum Categoria
    {
        
        D,
        AD
    }
    public class Dados
    {
  
        public int Id { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public List<int> EscolaId { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Apelido { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Cpf { get; set; }
        public DateTime  Data_Nascimento { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Prefixo { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Bairros { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Veiculo { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Placa { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public int Ano { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Cnh { get; set; }
        [NotMapped]
        public IFormFile FotoCnh { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public Categoria CategoriaSelecionada { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public DateTime Validade { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Endereco { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Bairro { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Cep { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string Número { get; set; }
        public string Complemento { get; set; }

        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public virtual Escola Escola { get; set; }
        [Required(ErrorMessage = ValidationMessage.Required)]
        [StringLength(60, ErrorMessage = ValidationMessage.StringLength)]
        public string EscolasSelecionadas { get; set; }
    




    }
}
