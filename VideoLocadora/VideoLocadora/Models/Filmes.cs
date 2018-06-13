using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoLocadora.Models
{
    public class Filmes
    {
        public int FilmeId { get; set; }

        [Required, StringLength(30)]
        public string Titulo { get; set; }
        public string Estoque { get; set; }
        public string Genero { get; set; }
        public string Classificacao { get; set; }
        
    }
}