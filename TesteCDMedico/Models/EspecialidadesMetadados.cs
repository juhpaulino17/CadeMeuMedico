using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteCDMedico.Models
{
    [MetadataType(typeof(EspecialidadesMetadados))]
    public class EspecialidadesMetadados
    {
        [Required(ErrorMessage = "Obrigatorio informar a Especialidade")]
        [MaxLength(30, ErrorMessage = "Quantidade de caracteres acima do permitido (30)")]
        public string Especialidade { get; set; }
    }
}