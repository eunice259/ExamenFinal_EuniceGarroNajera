using ExamenFinal_EuniceGarroNajera.CapaDatos;
using ExamenFinal_EuniceGarroNajera.CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal_EuniceGarroNajera.CapaLogica
{
    public class CategoriaService
    {
        public List<CategoriaMO> ObtenerTodas() => CategoriasDAO.Listar();

        public string Crear(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return "El nombre es obligatorio.";
            CategoriasDAO.Insertar(nombre.Trim());
            return "OK";
        }

        public string Editar(CategoriaMO c)
        {
            if (c.Id <= 0) return "Id inválido.";
            if (string.IsNullOrWhiteSpace(c.NombreCategoria)) return "Nombre obligatorio.";
            CategoriasDAO.Actualizar(c);
            return "OK";
        }

        public void Eliminar(int id) => CategoriasDAO.Eliminar(id);
    
}
}