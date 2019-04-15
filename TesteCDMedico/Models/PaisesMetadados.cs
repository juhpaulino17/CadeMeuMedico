using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteCDMedico.Models
{
    [MetadataType(typeof(PaisesMetadados))]
    public class PaisesMetadados
    {
        [Required(ErrorMessage = "Obrigatorio informar o nome do Pais")]
        [MaxLength(30, ErrorMessage = "Quantidade de caracteres acima do permitido (30)")]
        public string Pais { get; set; }


        [Required(ErrorMessage = "Obrigatorio informar a sigla do Pais")]
        [StringLength(2, ErrorMessage = "Quantidade de caracteres abaixo do permitido (2)")]
        public string Sigla { get; set; }
    }
}