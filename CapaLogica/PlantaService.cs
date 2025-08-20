using ExamenFinal_EuniceGarroNajera.CapaDatos;
using ExamenFinal_EuniceGarroNajera.CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenFinal_EuniceGarroNajera.CapaLogica
{
    public class PlantaService
    {
        public List<PlantaMO> Listar() => PlantasDAO.Listar();
        public List<PlantaMO> PorCategoria(int categoriaId) => PlantasDAO.PorCategoria(categoriaId);

        public string Crear(PlantaMO p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre)) return "El nombre es obligatorio.";
            if (p.CategoriaId <= 0) return "Seleccione una categoría.";
            PlantasDAO.Insertar(p);
            return "OK";
        }

        public string Editar(PlantaMO p)
        {
            if (p.Id <= 0) return "Id inválido.";
            if (string.IsNullOrWhiteSpace(p.Nombre)) return "El nombre es obligatorio.";
            if (p.CategoriaId <= 0) return "Seleccione una categoría.";
            PlantasDAO.Actualizar(p);
            return "OK";
        }

        public void Eliminar(int id) => PlantasDAO.Eliminar(id);
    }
}