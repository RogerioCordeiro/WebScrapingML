using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScraping.Entities.Vendedores
{
    public class Vendedor
    {
        public String? Nome { get; set; }
        public String? Id { get; set; }
        public String? Link { get; set; }
        public int QuantidadeAnuncios {  get; set; }
        
    }
}
