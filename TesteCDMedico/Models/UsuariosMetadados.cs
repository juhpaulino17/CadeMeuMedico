using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteCDMedico.Models
{
    [MetadataType(typeof(UsuariosMetadados))]
    public class UsuariosMetadados
    {
        [Required(ErrorMessage = "Obrigatorio informar o Nome")]
        [MaxLength(50, ErrorMessage = "Quantidade Invalida de caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Usuario")]
        [MaxLength(30, ErrorMessage = "Quantidade Invalida de caracteres")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Usuario")]
        [MaxLength(15, ErrorMessage = "Quantidade Invalida de caracteres")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Email")]
        [MaxLength(30, ErrorMessage = "Quantidade Invalida de caracteres")]
        public string Email { get; set; }

    }
}