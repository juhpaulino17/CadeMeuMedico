using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteCDMedico.Models
{
    [MetadataType(typeof(MedicosMetadados))]
    public class MedicosMetadados
        {
            [Required(ErrorMessage = "Obrigatorio informar o CRM")]
            [MaxLength(30, ErrorMessage = "O CRM deve possuir no maximo 30 caracteres")]
            public string CRM { get; set; }


            [Required(ErrorMessage = "Obrigatorio informar o Nome")]
            [MaxLength(50, ErrorMessage = "Quantidade Invalida de caracteres")]
            public string Nome { get; set; }

            [Required(ErrorMessage = "Obrigatorio informar o Endereço")]
            [MaxLength(100, ErrorMessage = "Quantidade Invalida de caracteres")]
            public string Endereco { get; set; }

            [Required(ErrorMessage = "Obrigatorio informar o Bairro")]
            [MaxLength(50, ErrorMessage = "Quantidade Invalida de caracteres")]
            public string Bairro { get; set; }

            [MaxLength(50, ErrorMessage = "Quantidade Invalidade de caracteres")]
            public string Email { get; set; }


            [Required(ErrorMessage = "Obrigatorio informar se há(TRUE) ou não(FALSE) o convenio")]
            [MaxLength(5, ErrorMessage = "Erro de sintaxe")]
            public bool PossuiConvenio { get; set; }


            [Required(ErrorMessage = "Obrigatorio informar se há(TRUE) ou não(FALSE) clinica")]
            [MaxLength(5, ErrorMessage = "Erro de sintaxe")]
            public bool PossuiClinica { get; set; }

        }
}