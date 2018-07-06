using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoLocadora.Models
{
    public class Reserva
        
    {   public int ReservaId { get; set; }
        public string NomeCliente { get; set; }
        public string Titulo { get; set; }
        public string Descrição { get; set; }
    }
}