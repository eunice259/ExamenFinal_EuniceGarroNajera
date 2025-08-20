using ExamenFinal_EuniceGarroNajera.CapaModelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamenFinal_EuniceGarroNajera.CapaDatos
{
    public class CategoriasDAO
    {
        public static List<CategoriaMO> Listar()
        {
            var list = new List<CategoriaMO>();
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spCategorias_Listar", con) { CommandType = CommandType.StoredProcedure })
            {
                con.Open();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        list.Add(new CategoriaMO
                        {
                            Id = (int)dr["Id"],
                            NombreCategoria = dr["NombreCategoria"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static void Insertar(string nombre)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spCategorias_Insertar", con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@NombreCategoria", nombre);
                con.Open(); cmd.ExecuteNonQuery();
            }
        }

        public static void Actualizar(CategoriaMO c)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spCategorias_Actualizar", con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Id", c.Id);
                cmd.Parameters.AddWithValue("@NombreCategoria", c.NombreCategoria);
                con.Open(); cmd.ExecuteNonQuery();
            }
        }

        public static void Eliminar(int id)
        {
            using (var con = new SqlConnection(Conexion.Cadena))
            using (var cmd = new SqlCommand("spCategorias_Eliminar", con) { CommandType = CommandType.StoredProcedure })
            {
                cmd.Parameters.AddWithValue("@Id", id);
                con.Open(); cmd.ExecuteNonQuery();
            }
        }
    }
}