using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteCDMedico.Models
{
    [MetadataType(typeof(CidadesMetadados))]
    public class CidadesMetadados
    {
        [Required(ErrorMessage = "Obrigatorio informar a cidade")]
        [MaxLength(30, ErrorMessage = "Quantidade de caracteres acima do permitido (30)")]
        public string Cidade{ get; set; }

    

    }
}