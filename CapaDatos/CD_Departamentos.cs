using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CapaDatos
{
    public class CD_Departamentos:Conexion
    {
        //***** METODO PARA LISTAR LOS DEPARTAMENTOS *****
        public List<CE_Departamentos> ListaDeptos()
        {
            List<CE_Departamentos> lista = new List<CE_Departamentos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "spListaDepartamentos";
                        command.CommandType = CommandType.StoredProcedure;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Departamentos()
                                {
                                    id_Depto = Convert.ToInt32(dr["id_Depto"]),
                                    Departamento = dr["Departamento"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Departamentos>();
                    }
                }
            }
            return lista;
        }

        //***** METODO PARA LISTAR LAS LOCALIDADES PARA UN COMBO *****
        public List<CE_Departamentos> ListaDepto()
        {
            List<CE_Departamentos> lista = new List<CE_Departamentos>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new MySqlCommand())
                {
                    try
                    {
                        command.Connection = connection;
                        command.CommandText = "SELECT DISTINCT Departamento, id_Depto FROM Departamentos ORDER BY Departamento ASC";
                        command.CommandType = CommandType.Text;
                        MySqlDataReader dr = command.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                lista.Add(new CE_Departamentos()
                                {
                                    id_Depto = Convert.ToInt32(dr["id_Depto"].ToString()),
                                    Departamento = dr["Departamento"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lista = new List<CE_Departamentos>();
                    }
                }
            }
            return lista;
        }

    }
}
