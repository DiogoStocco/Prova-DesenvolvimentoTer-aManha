using System;
using System.ComponentModel.DataAnnotations;
using API_Folha.Validations;

namespace API.Models
{
    public class FolhaPagamento
    {
      

        public FolhaPagamento() => CriadoEm = DateTime.Now;
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório!")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O campo CPF é obrigatório!")]
        [StringLength(
                11,
                MinimumLength = 11,
                ErrorMessage = "O campo CPF deve conter 11 caracteres!"
            )]
        // [CpfEmUso]
        public string Cpf { get; set; }

        public double Salario { get; set; }
        public DateTime CriadoEm { get; set; }

        public double Ir { get; set; }
        public double Inss { get; set; }
        public double Fgts { get; set; }

        public double SalarioB { get; set; }
    

        }
        
    }
