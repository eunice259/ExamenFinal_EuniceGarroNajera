using ExamenFinal_EuniceGarroNajera.CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenFinal_EuniceGarroNajera.CapaDatos
{
    public class PlantasDAO
    {
        public static List<PlantaMO> Listar()
        {
            var list = new List<PlantaMO>();
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spPlantas_Listar", con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new PlantaMO
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            CategoriaId = (int)dr["CategoriaId"],
                            CategoriaNombre = dr["NombreCategoria"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static void Insertar(PlantaMO p)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spPlantas_Insertar", con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)p.Descripcion ?? "");
                cmd.Parameters.AddWithValue("@CategoriaId", p.CategoriaId);
                con.Open(); cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(PlantaMO p)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spPlantas_Actualizar", con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Id", p.Id);
                cmd.Parameters.AddWithValue("@Nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", (object)p.Descripcion ?? "");
                cmd.Parameters.AddWithValue("@CategoriaId", p.CategoriaId);
                con.Open(); cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spPlantas_Eliminar", con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open(); cmd.ExecuteNonQuery();
            }
        }

        public static List<PlantaMO> PorCategoria(int categoriaId)
        {
            var list = new List<PlantaMO>();
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spPlantas_PorCategoria", con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@CategoriaId", categoriaId);
                con.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new PlantaMO
                        {
                            Id = (int)dr["Id"],
                            Nombre = dr["Nombre"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            CategoriaNombre = dr["NombreCategoria"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}