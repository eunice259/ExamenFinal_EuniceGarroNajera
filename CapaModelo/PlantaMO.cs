using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal_EuniceGarroNajera.CapaModelo
{
    public class PlantaMO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; } 

    }
}