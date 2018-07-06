using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoveLocadora.Models
{
    public class FilmesLocados
    {
        public int FilmesLocadosId { get; set; }
        [Required, StringLength(30)]
        public string NomeCliente { get; set; }
        public string NomeFilme { get; set; }
        public string Quantidade { get; set; }
        public string DataInicio { get; set; }
        public string DataFinal { get; set; }
    }
}