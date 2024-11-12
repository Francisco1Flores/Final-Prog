using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BA
{
    public class Nota
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string FechaHora { get; set; }

        public Nota(string titulo, string texto, string fechaHora)
        {
            Titulo = titulo;
            Texto = texto;
            FechaHora = fechaHora;
        }
    }
}
