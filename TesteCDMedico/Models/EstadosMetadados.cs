using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteCDMedico.Models
{
    [MetadataType(typeof(EstadosMetadados))]
    public class EstadosMetadados
    {

        [Required(ErrorMessage = "Obrigatorio informar o Estado")]
        [MaxLength(30, ErrorMessage = "Quantidade de caracteres acima do permitido (30)")]
        public string Estado{ get; set; }


        [Required(ErrorMessage = "Obrigatorio informar o UF do Estado")]
        [StringLength(2, ErrorMessage = "Quantidade de caracteres abaixo do permitido (2)")]
        public string UF { get; set; }

    }
}