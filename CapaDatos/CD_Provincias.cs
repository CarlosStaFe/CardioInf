using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Provincias:Conexion
    {
        //***** METODO PARA LISTAR LAS PROVINCIAS *****
        public List<CE_Provincias> ListaProvincias()
        {
            List<CE_Provincias> lista = new List<CE_Provincias>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SP_ListaProvincias";
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Provincias()
                                {
                                    id_Prov = Convert.ToInt32(dr["id_Prov"]),
                                    Provincia = dr["Provincia"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Provincias>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA LISTAR LAS PROVINCIAS PARA UN COMBO *****
        public List<CE_Provincias> ListaProvincia()
        {
            List<CE_Provincias> lista = new List<CE_Provincias>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT DISTINCT Provincia, id_Prov FROM Provincias ORDER BY Provincia ASC";
                        command.CommandType = CommandType.Text;
                        SqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Provincias()
                                {
                                    id_Prov = Convert.ToInt32(dr["id_Prov"].ToString()),
                                    Provincia = dr["Provincia"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Provincias>();
                    }
                }
            }
            return lista;
        }

    }
}
