using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apiGamesOfThrones.Models
{
    public class Temporada
    {
       
        public int id { get; set; }
        public string nombre { get; set; }
        public string anio { get; set; }
        public string cantEpisodios { get; set; }
        public string libro { get; set; }
        public Double rating { get; set; }
        public string foto { get; set; }
    }
}
