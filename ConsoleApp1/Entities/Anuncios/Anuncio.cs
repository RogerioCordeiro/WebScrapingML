using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping.Entities.Anuncios

{
    public class Anuncio
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? Link { get; set; }

    }
}
