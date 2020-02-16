using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entity
{
    public class Paciente
    {
        [Required]
        public int IdPaciente { get; set; }
        [Required(ErrorMessage = "Informe o Nome.")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "Informe a Idade.")]
        public int? Idade { get; set; }
        [Required(ErrorMessage = "Informe o Peso.")]
        public double? Peso { get; set; }
        [Required(ErrorMessage = "Informe a Altura.")]
        public double? Altura { get; set; }
    }
}
